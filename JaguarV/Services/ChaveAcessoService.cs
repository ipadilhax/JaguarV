using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace JaguarV.Services
{
    public class ChaveAcessoService
    {
        public bool ValidarChave(string chave, string competencia)
        {
            if (string.IsNullOrWhiteSpace(chave))
                return false;

            if (chave.Length != 44)
                return false;

            if (!chave.All(char.IsDigit))
                return false;

            string aamm = chave.Substring(2, 4);
            string modelo = chave.Substring(20, 2);

            if (modelo != "65")
                return false;

            if (!DateTime.TryParseExact(competencia, "yyyy-MM", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dataCompetencia))
                return false;

            string competenciaChave = dataCompetencia.ToString("yyMM");

            if (aamm != competenciaChave)
                return false;

            return true;
        }

        public string PegarCnpj(string chave)
        {
            return chave.Substring(6, 14);
        }

        public string PegarSerie(string chave)
        {
            return chave.Substring(22, 3);
        }
    }
}