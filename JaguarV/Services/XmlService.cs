using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using JaguarV.Models;

namespace JaguarV.Services
{
    public class XmlService
    {
        private readonly ChaveAcessoService chaveService = new ChaveAcessoService();

        public (int TotalArquivos, int NotasValidas, string CaminhoArquivo) VerificarXMLs(string diretorio, string competencia)
        {
            if (!Directory.Exists(diretorio))
                throw new DirectoryNotFoundException($"A pasta {diretorio} não foi encontrada.");

            string[] arquivosXml = Directory.GetFiles(diretorio, "*.xml");
            List<NotaEnvio> notasValidas = new List<NotaEnvio>();

            foreach (string arquivo in arquivosXml)
            {
                string? chave = PegarChaveDoNomeArquivo(arquivo);

                if (chave == null)
                    continue;

                if (!chaveService.ValidarChave(chave, competencia))
                    continue;

                try
                {
                    XDocument doc = XDocument.Load(arquivo);
                    NotaEnvio? nota = ValidarXML(doc, chave, competencia);

                    if (nota != null)
                        notasValidas.Add(nota);
                }
                catch
                {
                    continue;
                }
            }

            string caminhoArquivo = GerarArquivo(notasValidas, diretorio, competencia);

            return (arquivosXml.Length, notasValidas.Count, caminhoArquivo);
        }

        private string? PegarChaveDoNomeArquivo(string arquivo)
        {
            string nomeArquivo = Path.GetFileNameWithoutExtension(arquivo);
            Match resultado = Regex.Match(nomeArquivo, @"(?<!\d)\d{44}(?!\d)");

            if (!resultado.Success)
                return null;

            return resultado.Value;
        }

        private NotaEnvio? ValidarXML(XDocument doc, string chaveNomeArquivo, string competenciaDesejada)
        {
            XNamespace ns = "http://www.portalfiscal.inf.br/nfe";

            XElement? infNFe = doc.Descendants(ns + "infNFe").FirstOrDefault();
            XElement? ide = doc.Descendants(ns + "ide").FirstOrDefault();
            XElement? dest = doc.Descendants(ns + "dest").FirstOrDefault();

            if (infNFe == null || ide == null)
                return null;

            string? id = infNFe.Attribute("Id")?.Value;

            if (string.IsNullOrWhiteSpace(id))
                return null;

            string chaveXml = id.Trim();

            if (chaveXml.StartsWith("NFe"))
                chaveXml = chaveXml.Substring(3);

            if (chaveXml.Length != 44)
                return null;

            if (chaveXml != chaveNomeArquivo)
                return null;

            string? modelo = ide.Element(ns + "mod")?.Value.Trim();

            if (modelo != "65")
                return null;

            string? dataEmissao = ide.Element(ns + "dhEmi")?.Value.Trim();

            if (string.IsNullOrWhiteSpace(dataEmissao))
                return null;

            if (!DateTimeOffset.TryParse(dataEmissao, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTimeOffset data))
                return null;

            string competenciaXml = data.ToString("yyyy-MM");

            if (competenciaXml != competenciaDesejada)
                return null;

            string? cpf = dest?.Element(ns + "CPF")?.Value.Trim();
            string? cnpj = dest?.Element(ns + "CNPJ")?.Value.Trim();

            if (!string.IsNullOrWhiteSpace(cpf) || !string.IsNullOrWhiteSpace(cnpj))
                return null;

            return new NotaEnvio
            {
                Chave = chaveXml,
                Competencia = data.ToString("MM/yyyy")
            };
        }

        private string GerarArquivo(List<NotaEnvio> notas, string diretorio, string competencia)
        {
            string json = JsonSerializer.Serialize(notas, new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            string primeirosCincoCnpj = "00000";

            if (notas.Count > 0)
            {
                string cnpj = chaveService.PegarCnpj(notas[0].Chave);
                primeirosCincoCnpj = cnpj.Substring(0, 5);
            }

            DateTime data = DateTime.ParseExact(competencia, "yyyy-MM", CultureInfo.InvariantCulture);
            string nomeArquivo = data.ToString("MMyyyy") + primeirosCincoCnpj + ".txt";
            string caminhoArquivo = Path.Combine(diretorio, nomeArquivo);

            File.WriteAllText(caminhoArquivo, json);

            return caminhoArquivo;
        }
    }
}