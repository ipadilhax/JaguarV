using System.Diagnostics;
using JaguarV.Services;

namespace JaguarV
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();

            dtpCompetencia.Format = DateTimePickerFormat.Custom;
            dtpCompetencia.CustomFormat = "MM/yyyy";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            string competencia = dtpCompetencia.Value.ToString("yyyy-MM");
            string caminhoPasta = @"C:\XmlNfce";

            try
            {
                XmlService xmlService = new XmlService();
                var resultado = xmlService.VerificarXMLs(caminhoPasta, competencia);

                MessageBox.Show(
                    $"Processamento concluído!\n\nArquivos XML encontrados: {resultado.TotalArquivos}\nNotas válidas: {resultado.NotasValidas}\n\nArquivo gerado:\n{resultado.CaminhoArquivo}",
                    "JaguarV",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                Process.Start(new ProcessStartInfo
                {
                    FileName = resultado.CaminhoArquivo,
                    UseShellExecute = true
                });
            }
            catch (DirectoryNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "Pasta não encontrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao processar os arquivos:\n\n{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAjuda_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Como utilizar o JaguarV:\n\n" +
                "1. Coloque os arquivos XML na pasta:\n" +
                @"C:\XmlNfce" + "\n\n" +
                "2. Selecione o mês e o ano da competência desejada.\n" +
                "3. Clique no botão BUSCAR.\n\n" +
                "São consideradas válidas apenas as notas que:\n" +
                "- Possuem uma chave de acesso de 44 dígitos no nome do arquivo.\n" +
                "- São NFC-e do modelo 65.\n" +
                "- Pertencem à competência selecionada.\n" +
                "- Possuem a mesma chave de acesso dentro do XML.\n" +
                "- Não possuem CPF ou CNPJ informado no destinatário.\n\n" +
                "Após o processamento, o JaguarV gera e abre automaticamente o arquivo .txt contendo os dados em formato JSON.",
                "Ajuda - JaguarV",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void btnCreditos_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show(
                "JaguarV - XML Reader Project\n\n" +
                "Projeto desenvolvido por estudantes de Análise e Desenvolvimento de Sistemas da Unimar, turma 4A 2026.\n\n" +
                "Alunos:\n" +
                "Ruan Padilha\n" +
                "Victor Rodrigues Baptista\n" +
                "Gabriel de Freitas Barbosa\n" +
                "Jéssica Cristina Gabriel de Oliveira\n" +
                "Gustavo Henrique Costa dos Santos\n",
                "Créditos",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void btnSair_Click_1(object sender, EventArgs e)
        {
            DialogResult resposta = MessageBox.Show(
                "Deseja realmente sair do JaguarV?",
                "Sair",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resposta == DialogResult.Yes)
                Application.Exit();
        }
    }
}