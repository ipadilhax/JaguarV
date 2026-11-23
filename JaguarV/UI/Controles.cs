using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace JaguarV.UI
{
    /// <summary>
    /// Botão preenchido com cantos arredondados e cor de hover.
    /// A cor normal é o BackColor; a cor com o mouse em cima é CorHover.
    /// </summary>
    public class BotaoArredondado : Button
    {
        private bool _mouseEmCima;
        private bool _pressionado;

        [Category("Aparência"), DefaultValue(8)]
        public int Raio { get; set; } = 8;

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color CorHover { get; set; } = Color.Empty;

        public BotaoArredondado()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.UserPaint, true);

            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            Cursor = Cursors.Hand;
            UseVisualStyleBackColor = false;
        }

        protected override void OnMouseEnter(EventArgs e) { _mouseEmCima = true; Invalidate(); base.OnMouseEnter(e); }
        protected override void OnMouseLeave(EventArgs e) { _mouseEmCima = false; _pressionado = false; Invalidate(); base.OnMouseLeave(e); }
        protected override void OnMouseDown(MouseEventArgs e) { _pressionado = true; Invalidate(); base.OnMouseDown(e); }
        protected override void OnMouseUp(MouseEventArgs e) { _pressionado = false; Invalidate(); base.OnMouseUp(e); }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(Parent?.BackColor ?? SystemColors.Control);

            Color cor = BackColor;
            if (_mouseEmCima && !CorHover.IsEmpty) cor = CorHover;
            if (_pressionado) cor = ControlPaint.Dark(cor, 0.05f);

            var area = new Rectangle(0, 0, Width - 1, Height - 1);
            using (var caminho = CriarRetanguloArredondado(area, Raio))
            using (var pincel = new SolidBrush(cor))
            {
                g.FillPath(pincel, caminho);

                // Contorno de foco ao navegar com Tab
                if (Focused && ShowFocusCues)
                {
                    using var caneta = new Pen(ControlPaint.Dark(cor, 0.2f), 2);
                    g.DrawPath(caneta, caminho);
                }
            }

            TextRenderer.DrawText(g, Text, Font, ClientRectangle, ForeColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine);
        }

        internal static GraphicsPath CriarRetanguloArredondado(Rectangle r, int raio)
        {
            var caminho = new GraphicsPath();
            int d = Math.Max(1, Math.Min(raio * 2, Math.Min(r.Width, r.Height)));
            caminho.AddArc(r.X, r.Y, d, d, 180, 90);
            caminho.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            caminho.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            caminho.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            caminho.CloseFigure();
            return caminho;
        }
    }

    /// <summary>
    /// Uma linha do passo a passo: círculo com o número + texto ao lado.
    /// Usado no painel da esquerda quando a janela está maximizada.
    /// </summary>
    public class EtapaNumerada : Control
    {
        [Category("Aparência"), DefaultValue(1)]
        public int Numero { get; set; } = 1;

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color CorCirculo { get; set; } = Color.FromArgb(18, 53, 94);

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color CorNumero { get; set; } = Color.White;

        public EtapaNumerada()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.UserPaint |
                     ControlStyles.SupportsTransparentBackColor, true);
        }

        protected override void OnTextChanged(EventArgs e) { base.OnTextChanged(e); Invalidate(); }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int tamanho = 26;
            var circulo = new Rectangle(0, (Height - tamanho) / 2, tamanho, tamanho);
            using (var pincel = new SolidBrush(CorCirculo))
                g.FillEllipse(pincel, circulo);

            using (var fonteNumero = new Font(Font.FontFamily, 9.5F, FontStyle.Bold))
                TextRenderer.DrawText(g, Numero.ToString(), fonteNumero, circulo, CorNumero,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

            var areaTexto = new Rectangle(tamanho + 12, 0, Width - tamanho - 12, Height);
            TextRenderer.DrawText(g, Text, Font, areaTexto, ForeColor,
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
        }
    }
}