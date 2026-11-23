using System.Diagnostics;
using System.Runtime.InteropServices;
using JaguarV.Services;
using JaguarV.UI;

namespace JaguarV
{
    public partial class FormPrincipal : Form
    {
        // A partir desta largura a tela vira duas colunas (logo à esquerda, formulário à direita)
        private const int LarguraModoDesktop = 900;

        private Tema _tema = Tema.Claro;
        private bool? _modoDesktop;

        public FormPrincipal()
        {
            InitializeComponent();

            dtpCompetencia.Format = DateTimePickerFormat.Custom;
            dtpCompetencia.CustomFormat = "MM/yyyy";

            // O logo grande do modo desktop usa a mesma imagem do logo pequeno
            picLogoGrande.Image = pictureBox1.Image;

            AplicarTema(_tema);
            AtualizarLayout();
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            AplicarBarraDeTitulo();
        }

        // ---------------- Layout responsivo ----------------

        private void FormPrincipal_Resize(object? sender, EventArgs e) => AtualizarLayout();

        private void AtualizarLayout()
        {
            bool desktop = ClientSize.Width >= LarguraModoDesktop;
            if (_modoDesktop == desktop) return;
            _modoDesktop = desktop;

            tlpPrincipal.SuspendLayout();

            if (desktop)
            {
                tlpPrincipal.ColumnStyles[0] = new ColumnStyle(SizeType.Percent, 44F);
                tlpPrincipal.ColumnStyles[1] = new ColumnStyle(SizeType.Percent, 56F);
            }
            else
            {
                tlpPrincipal.ColumnStyles[0] = new ColumnStyle(SizeType.Absolute, 0F);
                tlpPrincipal.ColumnStyles[1] = new ColumnStyle(SizeType.Percent, 100F);
            }

            pnlMarca.Visible = desktop;
            pictureBox1.Visible = !desktop;   // no desktop o logo já aparece grande à esquerda
            lblTitulo.Font = new Font("Segoe UI Semibold", desktop ? 22F : 18F);

            tlpPrincipal.ResumeLayout(true);
            CentralizarMarca();
        }

        private void pnlMarca_Resize(object? sender, EventArgs e) => CentralizarMarca();

        private void CentralizarMarca()
        {
            flpMarca.Location = new Point(
                Math.Max(24, (pnlMarca.Width - flpMarca.Width) / 2),
                Math.Max(24, (pnlMarca.Height - flpMarca.Height) / 2));
        }

        // Linha fina separando o painel do logo do formulário
        private void pnlMarca_Paint(object? sender, PaintEventArgs e)
        {
            using var caneta = new Pen(_tema.Borda);
            e.Graphics.DrawLine(caneta, pnlMarca.Width - 1, 0, pnlMarca.Width - 1, pnlMarca.Height);
        }

        // ---------------- Tema claro / escuro ----------------

        private void btnTema_Click(object? sender, EventArgs e)
        {
            AplicarTema(_tema.Escuro ? Tema.Claro : Tema.Noturno);
        }

        private void AplicarTema(Tema t)
        {
            _tema = t;
            SuspendLayout();

            BackColor = t.Fundo;
            tlpPrincipal.BackColor = t.Fundo;
            flpConteudo.BackColor = t.Fundo;
            pnlAcoes.BackColor = t.Fundo;
            pnlRodape.BackColor = t.Fundo;
            pnlMarca.BackColor = t.PainelMarca;
            flpMarca.BackColor = t.PainelMarca;
            pnlSeparador.BackColor = t.Borda;

            lblTitulo.ForeColor = t.Texto;
            lblSubtitulo.ForeColor = t.TextoSecundario;
            lblCompetencia.ForeColor = t.TextoSecundario;
            lblDescricao.ForeColor = t.TextoSecundario;
            lblPasta.ForeColor = t.TextoSecundario;
            lblStatusPonto.ForeColor = t.Sucesso;

            PintarBotao(btnBuscar, t.Primario, t.PrimarioHover, t.PrimarioTexto);
            PintarBotao(btnAjuda, t.Suave, t.SuaveHover, t.SuaveTexto);
            PintarBotao(btnCreditos, t.Suave, t.SuaveHover, t.SuaveTexto);
            PintarBotao(btnTema, t.Suave, t.SuaveHover, t.SuaveTexto);
            PintarBotao(btnSair, t.Perigo, t.PerigoHover, t.PerigoTexto);
            btnTema.Text = t.Escuro ? "Tema claro" : "Tema escuro";

            foreach (var etapa in new[] { etapa1, etapa2, etapa3 })
            {
                etapa.ForeColor = t.Texto;
                etapa.CorCirculo = t.Etapa;
                etapa.CorNumero = t.EtapaTexto;
            }

            ResumeLayout(true);
            Invalidate(true);

            if (IsHandleCreated)
                AplicarBarraDeTitulo();
        }

        private static void PintarBotao(BotaoArredondado botao, Color fundo, Color hover, Color texto)
        {
            botao.BackColor = fundo;
            botao.CorHover = hover;
            botao.ForeColor = texto;
            botao.Invalidate();
        }

        // Deixa a barra de título escura no tema escuro (Windows 10 20H1+ e Windows 11)
        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int atributo, ref int valor, int tamanho);
        private const int DWMWA_USE_IMMERSIVE_DARK_MODE = 20;

        private void AplicarBarraDeTitulo()
        {
            int escuro = _tema.Escuro ? 1 : 0;
            DwmSetWindowAttribute(Handle, DWMWA_USE_IMMERSIVE_DARK_MODE, ref escuro, sizeof(int));
        }

        // ---------------- Ações dos botões (lógica igual à anterior) ----------------

        private void btnBuscar_Click_1(object? sender, EventArgs e)
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

        private void btnAjuda_Click_1(object? sender, EventArgs e)
        {
            MessageBox.Show(
                "Como utilizar o JaguarV:\n\n" +
                "1. Coloque os arquivos XML na pasta:\n" +
                @"C:\XmlNfce" + "\n\n" +
                "2. Selecione o mês e o ano da competência desejada.\n" +
                "3. Clique no botão Buscar notas.\n\n" +
                "São consideradas válidas apenas as notas que:\n" +
                "- Possuem uma chave de acesso de 44 dígitos no nome do arquivo.\n" +
                "- São NFC-e do modelo 65.\n" +
                "- Pertencem à competência selecionada.\n" +
                "- Possuem a mesma chave de acesso dentro do XML.\n" +
                "- Foram autorizadas pela SEFAZ (cStat = 100).\n" +
                "- Não possuem CPF ou CNPJ informado no destinatário.\n\n" +
                "Após o processamento, o JaguarV gera e abre automaticamente o arquivo .txt em formato JSON, com a chave, o modelo (65) e a competência (MM/AAAA) de cada nota.",
                "Ajuda - JaguarV",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void btnCreditos_Click_1(object? sender, EventArgs e)
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

        private void btnSair_Click_1(object? sender, EventArgs e)
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