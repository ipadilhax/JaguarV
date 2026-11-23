using System;
using System.Collections.Generic;
using System.Text;

namespace JaguarV.Models
{
    public class NotaEnvio
    {
        public string Chave { get; set; } = "";

        // Modelo do documento fiscal: 65 = NFC-e (o "série 65" das diretrizes)
        public string Modelo { get; set; } = "";

        public string Competencia { get; set; } = "";
    }
}
