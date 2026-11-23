using System.Text.Json;
using JaguarV.Services;
using Xunit;

namespace JaguarV.Tests
{
    // Testes do processamento completo (VerificarXMLs) usando uma pasta temporária
    // no lugar de C:\XmlNfce, para não depender da máquina.
    public class XmlServiceTests : IDisposable
    {
        private const string Competencia = "2026-09";
        private const string ArquivoEsperado = "09202612345.txt";

        private readonly string _pasta;
        private readonly XmlService _service = new XmlService();

        public XmlServiceTests()
        {
            _pasta = Path.Combine(Path.GetTempPath(), "JaguarVTeste_" + Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(_pasta);
        }

        public void Dispose()
        {
            Directory.Delete(_pasta, recursive: true);
        }

        private void CriarXml(string nomeArquivo, string conteudo)
        {
            File.WriteAllText(Path.Combine(_pasta, nomeArquivo), conteudo);
        }

        private static JsonElement[] LerNotas(string caminho)
        {
            using var json = JsonDocument.Parse(File.ReadAllText(caminho));
            return json.RootElement.EnumerateArray().Select(e => e.Clone()).ToArray();
        }

        [Fact(DisplayName = "TA04 - Pasta inexistente lança DirectoryNotFoundException")]
        public void TA04_PastaInexistente_LancaExcecao()
        {
            string pasta = Path.Combine(_pasta, "nao_existe");

            var ex = Assert.Throws<DirectoryNotFoundException>(() => _service.VerificarXMLs(pasta, Competencia));
            Assert.Contains("não foi encontrada", ex.Message);
        }

        [Fact(DisplayName = "TA05 - Nota válida gera o arquivo MMAAAA + 5 dígitos do CNPJ com chave e competência")]
        public void TA05_NotaValida_GeraArquivo()
        {
            string chave = NfceTeste.Chave();
            CriarXml($"{chave}-procNFe.xml", NfceTeste.Xml(chave));

            var (total, validas, caminho) = _service.VerificarXMLs(_pasta, Competencia);

            Assert.Equal(1, total);
            Assert.Equal(1, validas);
            Assert.Equal(Path.Combine(_pasta, ArquivoEsperado), caminho);

            var nota = Assert.Single(LerNotas(caminho));
            Assert.Equal(chave, nota.GetProperty("chave").GetString());
            Assert.Equal("09/2026", nota.GetProperty("competencia").GetString());
        }

        [Fact(DisplayName = "TA06 - Arquivo sem chave de 44 dígitos no nome é ignorado")]
        public void TA06_NomeSemChave_Ignorado()
        {
            CriarXml("nota_teste.xml", NfceTeste.Xml(NfceTeste.Chave()));

            var (total, validas, _) = _service.VerificarXMLs(_pasta, Competencia);

            Assert.Equal(1, total);
            Assert.Equal(0, validas);
        }

        [Fact(DisplayName = "TA07 - Chave do nome do arquivo diferente da chave do XML é descartada")]
        public void TA07_ChaveDivergente_Descartada()
        {
            string chaveNome = NfceTeste.Chave(numero: "000000001");
            string chaveXml = NfceTeste.Chave(numero: "000000002");
            CriarXml($"{chaveNome}.xml", NfceTeste.Xml(chaveXml));

            var (_, validas, _) = _service.VerificarXMLs(_pasta, Competencia);

            Assert.Equal(0, validas);
        }

        [Fact(DisplayName = "TA08 - XML com modelo diferente de 65 na tag <mod> é descartado")]
        public void TA08_ModeloXmlDiferente_Descartado()
        {
            string chave = NfceTeste.Chave();
            CriarXml($"{chave}.xml", NfceTeste.Xml(chave, modelo: "55"));

            var (_, validas, _) = _service.VerificarXMLs(_pasta, Competencia);

            Assert.Equal(0, validas);
        }

        [Fact(DisplayName = "TA09 - XML com data de emissão fora da competência é descartado")]
        public void TA09_DataEmissaoDivergente_Descartada()
        {
            string chave = NfceTeste.Chave();
            CriarXml($"{chave}.xml", NfceTeste.Xml(chave, dhEmi: "2026-10-01T08:00:00-03:00"));

            var (_, validas, _) = _service.VerificarXMLs(_pasta, Competencia);

            Assert.Equal(0, validas);
        }

        [Fact(DisplayName = "TA10 - Nota com CPF do destinatário é descartada")]
        public void TA10_DestinatarioComCpf_Descartada()
        {
            string chave = NfceTeste.Chave();
            CriarXml($"{chave}.xml", NfceTeste.Xml(chave, dest: "<CPF>12345678909</CPF>"));

            var (_, validas, _) = _service.VerificarXMLs(_pasta, Competencia);

            Assert.Equal(0, validas);
        }

        [Fact(DisplayName = "TA11 - Nota com CNPJ do destinatário é descartada")]
        public void TA11_DestinatarioComCnpj_Descartada()
        {
            string chave = NfceTeste.Chave();
            CriarXml($"{chave}.xml", NfceTeste.Xml(chave, dest: "<CNPJ>98765432000198</CNPJ>"));

            var (_, validas, _) = _service.VerificarXMLs(_pasta, Competencia);

            Assert.Equal(0, validas);
        }

        [Fact(DisplayName = "TA12 - XML corrompido não interrompe o processamento das demais notas")]
        public void TA12_XmlCorrompido_NaoInterrompe()
        {
            string chaveValida = NfceTeste.Chave(numero: "000000001");
            string chaveCorrompida = NfceTeste.Chave(numero: "000000002");
            CriarXml($"{chaveValida}.xml", NfceTeste.Xml(chaveValida));
            CriarXml($"{chaveCorrompida}.xml", "<nfeProc><NFe>");

            var (total, validas, _) = _service.VerificarXMLs(_pasta, Competencia);

            Assert.Equal(2, total);
            Assert.Equal(1, validas);
        }

        [Fact(DisplayName = "TA13 - Sem notas válidas, o arquivo usa 00000 no nome e contém lista vazia")]
        public void TA13_SemNotasValidas_ArquivoVazio()
        {
            var (total, validas, caminho) = _service.VerificarXMLs(_pasta, Competencia);

            Assert.Equal(0, total);
            Assert.Equal(0, validas);
            Assert.Equal(Path.Combine(_pasta, "09202600000.txt"), caminho);
            Assert.Empty(LerNotas(caminho));
        }
    }
}
