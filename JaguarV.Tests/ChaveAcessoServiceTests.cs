using JaguarV.Services;
using Xunit;

namespace JaguarV.Tests
{
    // Testes da validação e extração de dados da chave de acesso.
    public class ChaveAcessoServiceTests
    {
        private readonly ChaveAcessoService _service = new ChaveAcessoService();

        [Fact(DisplayName = "TA01 - Chave válida de NFC-e na competência informada é aceita")]
        public void TA01_ChaveValida_RetornaTrue()
        {
            Assert.True(_service.ValidarChave(NfceTeste.Chave(), "2026-09"));
        }

        [Fact(DisplayName = "TA02 - Chave inválida é recusada (curta, com letra, modelo 55 ou outra competência)")]
        public void TA02_ChaveInvalida_RetornaFalse()
        {
            string chaveComLetra = "A" + NfceTeste.Chave().Substring(1);

            Assert.False(_service.ValidarChave("352609123456", "2026-09"));
            Assert.False(_service.ValidarChave(chaveComLetra, "2026-09"));
            Assert.False(_service.ValidarChave(NfceTeste.Chave(modelo: "55"), "2026-09"));
            Assert.False(_service.ValidarChave(NfceTeste.Chave(aamm: "2608"), "2026-09"));
        }

        [Fact(DisplayName = "TA03 - PegarCnpj e PegarSerie extraem os dados das posições corretas")]
        public void TA03_ExtraiCnpjESerie()
        {
            string chave = NfceTeste.Chave(serie: "123");

            Assert.Equal(NfceTeste.Cnpj, _service.PegarCnpj(chave));
            Assert.Equal("123", _service.PegarSerie(chave));
        }
    }
}
