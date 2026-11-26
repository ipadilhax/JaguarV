namespace JaguarV
{
    partial class FormPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            tlpPrincipal = new TableLayoutPanel();
            pnlMarca = new Panel();
            flpMarca = new FlowLayoutPanel();
            picLogoGrande = new PictureBox();
            lblDescricao = new Label();
            etapa1 = new JaguarV.UI.EtapaNumerada();
            etapa2 = new JaguarV.UI.EtapaNumerada();
            etapa3 = new JaguarV.UI.EtapaNumerada();
            flpConteudo = new FlowLayoutPanel();
            pictureBox1 = new PictureBox();
            lblTitulo = new Label();
            lblSubtitulo = new Label();
            lblCompetencia = new Label();
            dtpCompetencia = new DateTimePicker();
            btnBuscar = new JaguarV.UI.BotaoArredondado();
            pnlSeparador = new Panel();
            pnlAcoes = new Panel();
            btnAjuda = new JaguarV.UI.BotaoArredondado();
            btnCreditos = new JaguarV.UI.BotaoArredondado();
            btnSair = new JaguarV.UI.BotaoArredondado();
            pnlRodape = new Panel();
            lblStatusPonto = new Label();
            lblPasta = new Label();
            btnTema = new JaguarV.UI.BotaoArredondado();
            tlpPrincipal.SuspendLayout();
            pnlMarca.SuspendLayout();
            flpMarca.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogoGrande).BeginInit();
            flpConteudo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            pnlAcoes.SuspendLayout();
            pnlRodape.SuspendLayout();
            SuspendLayout();
            //
            // tlpPrincipal
            //
            tlpPrincipal.ColumnCount = 2;
            tlpPrincipal.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 0F));
            tlpPrincipal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpPrincipal.Controls.Add(pnlMarca, 0, 0);
            tlpPrincipal.Controls.Add(flpConteudo, 1, 0);
            tlpPrincipal.Dock = DockStyle.Fill;
            tlpPrincipal.Location = new Point(0, 0);
            tlpPrincipal.Margin = new Padding(0);
            tlpPrincipal.Name = "tlpPrincipal";
            tlpPrincipal.RowCount = 1;
            tlpPrincipal.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpPrincipal.Size = new Size(384, 641);
            tlpPrincipal.TabIndex = 0;
            //
            // pnlMarca
            //
            pnlMarca.Controls.Add(flpMarca);
            pnlMarca.Dock = DockStyle.Fill;
            pnlMarca.Location = new Point(0, 0);
            pnlMarca.Margin = new Padding(0);
            pnlMarca.Name = "pnlMarca";
            pnlMarca.Size = new Size(1, 641);
            pnlMarca.TabIndex = 0;
            pnlMarca.Visible = false;
            pnlMarca.Paint += pnlMarca_Paint;
            pnlMarca.Resize += pnlMarca_Resize;
            //
            // flpMarca
            //
            flpMarca.AutoSize = true;
            flpMarca.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flpMarca.Controls.Add(picLogoGrande);
            flpMarca.Controls.Add(lblDescricao);
            flpMarca.Controls.Add(etapa1);
            flpMarca.Controls.Add(etapa2);
            flpMarca.Controls.Add(etapa3);
            flpMarca.FlowDirection = FlowDirection.TopDown;
            flpMarca.Location = new Point(0, 0);
            flpMarca.Margin = new Padding(0);
            flpMarca.Name = "flpMarca";
            flpMarca.Size = new Size(400, 431);
            flpMarca.TabIndex = 0;
            flpMarca.WrapContents = false;
            //
            // picLogoGrande
            //
            picLogoGrande.Location = new Point(0, 0);
            picLogoGrande.Margin = new Padding(0, 0, 0, 20);
            picLogoGrande.Name = "picLogoGrande";
            picLogoGrande.Size = new Size(380, 253);
            picLogoGrande.SizeMode = PictureBoxSizeMode.Zoom;
            picLogoGrande.TabIndex = 0;
            picLogoGrande.TabStop = false;
            //
            // lblDescricao
            //
            lblDescricao.AutoSize = true;
            lblDescricao.Font = new Font("Segoe UI", 11F);
            lblDescricao.Location = new Point(0, 273);
            lblDescricao.Margin = new Padding(0, 0, 0, 20);
            lblDescricao.MaximumSize = new Size(400, 0);
            lblDescricao.Name = "lblDescricao";
            lblDescricao.Size = new Size(396, 60);
            lblDescricao.TabIndex = 1;
            lblDescricao.Text = "Lê os XMLs de NFC-e da pasta local e gera o arquivo com as notas de consumidor não identificado da competência escolhida.";
            //
            // etapa1
            //
            etapa1.Font = new Font("Segoe UI", 10.5F);
            etapa1.Location = new Point(0, 337);
            etapa1.Margin = new Padding(0, 0, 0, 4);
            etapa1.Name = "etapa1";
            etapa1.Numero = 1;
            etapa1.Size = new Size(400, 30);
            etapa1.TabIndex = 2;
            etapa1.Text = "Coloque os XMLs em C:\\XmlNfce";
            //
            // etapa2
            //
            etapa2.Font = new Font("Segoe UI", 10.5F);
            etapa2.Location = new Point(0, 371);
            etapa2.Margin = new Padding(0, 0, 0, 4);
            etapa2.Name = "etapa2";
            etapa2.Numero = 2;
            etapa2.Size = new Size(400, 30);
            etapa2.TabIndex = 3;
            etapa2.Text = "Escolha o mês e o ano da competência";
            //
            // etapa3
            //
            etapa3.Font = new Font("Segoe UI", 10.5F);
            etapa3.Location = new Point(0, 405);
            etapa3.Margin = new Padding(0);
            etapa3.Name = "etapa3";
            etapa3.Numero = 3;
            etapa3.Size = new Size(400, 30);
            etapa3.TabIndex = 4;
            etapa3.Text = "Clique em Buscar notas";
            //
            // flpConteudo
            //
            flpConteudo.Anchor = AnchorStyles.None;
            flpConteudo.AutoSize = true;
            flpConteudo.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flpConteudo.Controls.Add(pictureBox1);
            flpConteudo.Controls.Add(lblTitulo);
            flpConteudo.Controls.Add(lblSubtitulo);
            flpConteudo.Controls.Add(lblCompetencia);
            flpConteudo.Controls.Add(dtpCompetencia);
            flpConteudo.Controls.Add(btnBuscar);
            flpConteudo.Controls.Add(pnlSeparador);
            flpConteudo.Controls.Add(pnlAcoes);
            flpConteudo.Controls.Add(pnlRodape);
            flpConteudo.FlowDirection = FlowDirection.TopDown;
            flpConteudo.Location = new Point(32, 52);
            flpConteudo.Margin = new Padding(0);
            flpConteudo.Name = "flpConteudo";
            flpConteudo.Size = new Size(320, 536);
            flpConteudo.TabIndex = 1;
            flpConteudo.WrapContents = false;
            //
            // pictureBox1
            //
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(40, 0);
            pictureBox1.Margin = new Padding(40, 0, 40, 16);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(240, 160);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI Semibold", 18F);
            lblTitulo.Location = new Point(0, 176);
            lblTitulo.Margin = new Padding(0, 0, 0, 2);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(176, 32);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "Bem-vindo(a)!";
            //
            // lblSubtitulo
            //
            lblSubtitulo.Font = new Font("Segoe UI", 9.75F);
            lblSubtitulo.Location = new Point(0, 210);
            lblSubtitulo.Margin = new Padding(0, 0, 0, 16);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(320, 40);
            lblSubtitulo.TabIndex = 2;
            lblSubtitulo.Text = "Escolha a competência e clique em Buscar para gerar o arquivo das NFC-e.";
            //
            // lblCompetencia
            //
            lblCompetencia.AutoSize = true;
            lblCompetencia.Font = new Font("Segoe UI Semibold", 9F);
            lblCompetencia.Location = new Point(0, 266);
            lblCompetencia.Margin = new Padding(0, 0, 0, 6);
            lblCompetencia.Name = "lblCompetencia";
            lblCompetencia.Size = new Size(77, 15);
            lblCompetencia.TabIndex = 3;
            lblCompetencia.Text = "Competência";
            //
            // dtpCompetencia
            //
            dtpCompetencia.CustomFormat = "MM/yyyy";
            dtpCompetencia.Font = new Font("Segoe UI", 11.25F);
            dtpCompetencia.Format = DateTimePickerFormat.Custom;
            dtpCompetencia.Location = new Point(0, 287);
            dtpCompetencia.Margin = new Padding(0, 0, 0, 12);
            dtpCompetencia.Name = "dtpCompetencia";
            dtpCompetencia.Size = new Size(320, 27);
            dtpCompetencia.TabIndex = 4;
            //
            // btnBuscar
            //
            btnBuscar.Font = new Font("Segoe UI Semibold", 11F);
            btnBuscar.Location = new Point(0, 326);
            btnBuscar.Margin = new Padding(0);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(320, 46);
            btnBuscar.TabIndex = 5;
            btnBuscar.Text = "Buscar notas";
            btnBuscar.Click += btnBuscar_Click_1;
            //
            // pnlSeparador
            //
            pnlSeparador.Location = new Point(0, 392);
            pnlSeparador.Margin = new Padding(0, 20, 0, 16);
            pnlSeparador.Name = "pnlSeparador";
            pnlSeparador.Size = new Size(320, 1);
            pnlSeparador.TabIndex = 6;
            //
            // pnlAcoes
            //
            pnlAcoes.Controls.Add(btnAjuda);
            pnlAcoes.Controls.Add(btnCreditos);
            pnlAcoes.Controls.Add(btnSair);
            pnlAcoes.Location = new Point(0, 409);
            pnlAcoes.Margin = new Padding(0);
            pnlAcoes.Name = "pnlAcoes";
            pnlAcoes.Size = new Size(320, 40);
            pnlAcoes.TabIndex = 7;
            //
            // btnAjuda
            //
            btnAjuda.Font = new Font("Segoe UI Semibold", 10F);
            btnAjuda.Location = new Point(0, 0);
            btnAjuda.Name = "btnAjuda";
            btnAjuda.Size = new Size(100, 40);
            btnAjuda.TabIndex = 0;
            btnAjuda.Text = "Ajuda";
            btnAjuda.Click += btnAjuda_Click_1;
            //
            // btnCreditos
            //
            btnCreditos.Font = new Font("Segoe UI Semibold", 10F);
            btnCreditos.Location = new Point(110, 0);
            btnCreditos.Name = "btnCreditos";
            btnCreditos.Size = new Size(100, 40);
            btnCreditos.TabIndex = 1;
            btnCreditos.Text = "Créditos";
            btnCreditos.Click += btnCreditos_Click_1;
            //
            // btnSair
            //
            btnSair.Font = new Font("Segoe UI Semibold", 10F);
            btnSair.Location = new Point(220, 0);
            btnSair.Name = "btnSair";
            btnSair.Size = new Size(100, 40);
            btnSair.TabIndex = 2;
            btnSair.Text = "Sair";
            btnSair.Click += btnSair_Click_1;
            //
            // pnlRodape
            //
            pnlRodape.Controls.Add(lblStatusPonto);
            pnlRodape.Controls.Add(lblPasta);
            pnlRodape.Controls.Add(btnTema);
            pnlRodape.Location = new Point(0, 467);
            pnlRodape.Margin = new Padding(0, 18, 0, 0);
            pnlRodape.Name = "pnlRodape";
            pnlRodape.Size = new Size(320, 30);
            pnlRodape.TabIndex = 8;
            //
            // lblStatusPonto
            //
            lblStatusPonto.AutoSize = true;
            lblStatusPonto.Font = new Font("Segoe UI", 8F);
            lblStatusPonto.Location = new Point(0, 8);
            lblStatusPonto.Name = "lblStatusPonto";
            lblStatusPonto.Size = new Size(14, 13);
            lblStatusPonto.TabIndex = 0;
            lblStatusPonto.Text = "●";
            //
            // lblPasta
            //
            lblPasta.AutoSize = true;
            lblPasta.Font = new Font("Segoe UI", 9F);
            lblPasta.Location = new Point(14, 7);
            lblPasta.Name = "lblPasta";
            lblPasta.Size = new Size(113, 15);
            lblPasta.TabIndex = 1;
            lblPasta.Text = "Pasta: C:\\XmlNfce";
            //
            // btnTema
            //
            btnTema.Font = new Font("Segoe UI Semibold", 9F);
            btnTema.Location = new Point(200, 0);
            btnTema.Name = "btnTema";
            btnTema.Raio = 6;
            btnTema.Size = new Size(120, 30);
            btnTema.TabIndex = 2;
            btnTema.Text = "Tema escuro";
            btnTema.Click += btnTema_Click;
            //
            // FormPrincipal
            //
            AcceptButton = btnBuscar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 641);
            Controls.Add(tlpPrincipal);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(400, 680);
            Name = "FormPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "JaguarV";
            Resize += FormPrincipal_Resize;
            tlpPrincipal.ResumeLayout(false);
            tlpPrincipal.PerformLayout();
            pnlMarca.ResumeLayout(false);
            pnlMarca.PerformLayout();
            flpMarca.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picLogoGrande).EndInit();
            flpConteudo.ResumeLayout(false);
            flpConteudo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            pnlAcoes.ResumeLayout(false);
            pnlRodape.ResumeLayout(false);
            pnlRodape.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpPrincipal;
        private Panel pnlMarca;
        private FlowLayoutPanel flpMarca;
        private PictureBox picLogoGrande;
        private Label lblDescricao;
        private JaguarV.UI.EtapaNumerada etapa1;
        private JaguarV.UI.EtapaNumerada etapa2;
        private JaguarV.UI.EtapaNumerada etapa3;
        private FlowLayoutPanel flpConteudo;
        private PictureBox pictureBox1;
        private Label lblTitulo;
        private Label lblSubtitulo;
        private Label lblCompetencia;
        private DateTimePicker dtpCompetencia;
        private JaguarV.UI.BotaoArredondado btnBuscar;
        private Panel pnlSeparador;
        private Panel pnlAcoes;
        private JaguarV.UI.BotaoArredondado btnAjuda;
        private JaguarV.UI.BotaoArredondado btnCreditos;
        private JaguarV.UI.BotaoArredondado btnSair;
        private Panel pnlRodape;
        private Label lblStatusPonto;
        private Label lblPasta;
        private JaguarV.UI.BotaoArredondado btnTema;
    }
}