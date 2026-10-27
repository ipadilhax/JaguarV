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
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            dtpCompetencia = new DateTimePicker();
            btnBuscar = new Button();
            button2 = new Button();
            btnSair = new Button();
            btnCreditos = new Button();
            btnAjuda = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(44, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(265, 188);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.GradientInactiveCaption;
            label1.Cursor = Cursors.SizeNESW;
            label1.Font = new Font("Showcard Gothic", 19F, FontStyle.Bold);
            label1.Location = new Point(37, 234);
            label1.Name = "label1";
            label1.Size = new Size(283, 33);
            label1.TabIndex = 2;
            label1.Text = "Seja Bem-Vindo(a)!";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.GradientInactiveCaption;
            label2.Cursor = Cursors.SizeNESW;
            label2.Font = new Font("Showcard Gothic", 14F, FontStyle.Bold);
            label2.Location = new Point(52, 301);
            label2.Name = "label2";
            label2.Size = new Size(248, 23);
            label2.TabIndex = 3;
            label2.Text = "Insira a competência:";
            label2.Click += label2_Click;
            // 
            // dtpCompetencia
            // 
            dtpCompetencia.CalendarMonthBackground = SystemColors.GradientActiveCaption;
            dtpCompetencia.CustomFormat = "MM/yyyy";
            dtpCompetencia.Font = new Font("Showcard Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpCompetencia.Format = DateTimePickerFormat.Custom;
            dtpCompetencia.Location = new Point(44, 337);
            dtpCompetencia.Name = "dtpCompetencia";
            dtpCompetencia.Size = new Size(265, 26);
            dtpCompetencia.TabIndex = 4;
            // 
            // btnBuscar
            // 
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.Font = new Font("Showcard Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBuscar.Location = new Point(44, 379);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(265, 37);
            btnBuscar.TabIndex = 5;
            btnBuscar.Text = "BUSCAR";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click_1;
            // 
            // button2
            // 
            button2.Location = new Point(213, 479);
            button2.Name = "button2";
            button2.Size = new Size(8, 8);
            button2.TabIndex = 6;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            // 
            // btnSair
            // 
            btnSair.BackColor = SystemColors.GradientInactiveCaption;
            btnSair.FlatStyle = FlatStyle.Flat;
            btnSair.Font = new Font("Showcard Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSair.ForeColor = Color.Red;
            btnSair.Location = new Point(198, 479);
            btnSair.Name = "btnSair";
            btnSair.Size = new Size(111, 40);
            btnSair.TabIndex = 7;
            btnSair.Text = "SAIR";
            btnSair.UseVisualStyleBackColor = false;
            btnSair.Click += btnSair_Click_1;
            // 
            // btnCreditos
            // 
            btnCreditos.FlatStyle = FlatStyle.Flat;
            btnCreditos.Font = new Font("Showcard Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCreditos.ForeColor = Color.Blue;
            btnCreditos.Location = new Point(121, 543);
            btnCreditos.Name = "btnCreditos";
            btnCreditos.Size = new Size(111, 40);
            btnCreditos.TabIndex = 8;
            btnCreditos.Text = "Créditos";
            btnCreditos.UseVisualStyleBackColor = true;
            btnCreditos.Click += btnCreditos_Click_1;
            // 
            // btnAjuda
            // 
            btnAjuda.FlatStyle = FlatStyle.Flat;
            btnAjuda.Font = new Font("Showcard Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAjuda.ForeColor = Color.Green;
            btnAjuda.Location = new Point(44, 479);
            btnAjuda.Name = "btnAjuda";
            btnAjuda.Size = new Size(111, 40);
            btnAjuda.TabIndex = 9;
            btnAjuda.Text = "AJUDA";
            btnAjuda.UseVisualStyleBackColor = true;
            btnAjuda.Click += btnAjuda_Click_1;
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(361, 618);
            Controls.Add(btnAjuda);
            Controls.Add(btnCreditos);
            Controls.Add(btnSair);
            Controls.Add(button2);
            Controls.Add(btnBuscar);
            Controls.Add(dtpCompetencia);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormPrincipal";
            Text = "JaguarV";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private DateTimePicker dtpCompetencia;
        private Button btnBuscar;
        private Button button2;
        private Button btnSair;
        private Button btnCreditos;
        private Button btnAjuda;
    }
}
