namespace JaguarV.Tests
{
    // Gera chaves de acesso e XMLs de NFC-e para os testes.
    // Layout da chave: cUF(2) AAMM(4) CNPJ(14) mod(2) serie(3) nNF(9) tpEmis(1) cNF(8) DV(1)
    public static class NfceTeste
    {
        public const string Cnpj = "12345678000195";

        public static string Chave(string aamm = "2609", string modelo = "65", string serie = "001", string numero = "000000001")
        {
            string semDv = "35" + aamm + Cnpj + modelo + serie + numero + "1" + "00000001";
            return semDv + DigitoVerificador(semDv);
        }

        public static string Xml(
            string chave,
            string modelo = "65",
            string dhEmi = "2026-09-15T10:00:00-03:00",
            string dest = "")
        {
            return $"""
                <?xml version="1.0" encoding="utf-8"?>
                <nfeProc xmlns="http://www.portalfiscal.inf.br/nfe">
                  <NFe>
                    <infNFe Id="NFe{chave}">
                      <ide>
                        <mod>{modelo}</mod>
                        <serie>1</serie>
                        <dhEmi>{dhEmi}</dhEmi>
                      </ide>
                      <dest>{dest}</dest>
                      <total>
                        <ICMSTot>
                          <vNF>150.00</vNF>
                        </ICMSTot>
                      </total>
                    </infNFe>
                  </NFe>
                </nfeProc>
                """;
        }

        // Módulo 11 com pesos de 2 a 9, da direita para a esquerda (padrão da NF-e).
        private static int DigitoVerificador(string chave43)
        {
            int soma = 0;
            int peso = 2;

            for (int i = chave43.Length - 1; i >= 0; i--)
            {
                soma += (chave43[i] - '0') * peso;
                peso = peso == 9 ? 2 : peso + 1;
            }

            int resto = soma % 11;
            return resto < 2 ? 0 : 11 - resto;
        }
    }
}
