namespace JaguarV.UI
{
    /// <summary>
    /// Paleta de cores do JaguarV. Todas as cores da tela saem daqui,
    /// então para ajustar um tom basta mudar neste arquivo.
    /// </summary>
    public sealed class Tema
    {
        public bool Escuro { get; init; }

        // Superfícies
        public Color Fundo { get; init; }
        public Color PainelMarca { get; init; }
        public Color Borda { get; init; }

        // Textos
        public Color Texto { get; init; }
        public Color TextoSecundario { get; init; }

        // Botão principal (Buscar)
        public Color Primario { get; init; }
        public Color PrimarioHover { get; init; }
        public Color PrimarioTexto { get; init; }

        // Botões secundários (Ajuda, Créditos, Tema)
        public Color Suave { get; init; }
        public Color SuaveHover { get; init; }
        public Color SuaveTexto { get; init; }

        // Botão Sair
        public Color Perigo { get; init; }
        public Color PerigoHover { get; init; }
        public Color PerigoTexto { get; init; }

        // Detalhes
        public Color Sucesso { get; init; }
        public Color Etapa { get; init; }
        public Color EtapaTexto { get; init; }

        public static readonly Tema Claro = new()
        {
            Escuro = false,
            Fundo = Color.FromArgb(255, 255, 255),
            PainelMarca = Color.FromArgb(242, 246, 251),
            Borda = Color.FromArgb(227, 232, 239),
            Texto = Color.FromArgb(16, 35, 61),
            TextoSecundario = Color.FromArgb(93, 111, 134),
            Primario = Color.FromArgb(18, 53, 94),
            PrimarioHover = Color.FromArgb(26, 74, 128),
            PrimarioTexto = Color.White,
            Suave = Color.FromArgb(234, 240, 247),
            SuaveHover = Color.FromArgb(221, 231, 242),
            SuaveTexto = Color.FromArgb(18, 53, 94),
            Perigo = Color.FromArgb(253, 236, 236),
            PerigoHover = Color.FromArgb(250, 220, 220),
            PerigoTexto = Color.FromArgb(180, 35, 35),
            Sucesso = Color.FromArgb(46, 158, 91),
            Etapa = Color.FromArgb(18, 53, 94),
            EtapaTexto = Color.White
        };

        public static readonly Tema Noturno = new()
        {
            Escuro = true,
            Fundo = Color.FromArgb(15, 26, 42),
            PainelMarca = Color.FromArgb(11, 20, 34),
            Borda = Color.FromArgb(34, 50, 74),
            Texto = Color.FromArgb(233, 238, 245),
            TextoSecundario = Color.FromArgb(148, 166, 189),
            Primario = Color.FromArgb(240, 144, 31),
            PrimarioHover = Color.FromArgb(246, 164, 64),
            PrimarioTexto = Color.FromArgb(26, 17, 4),
            Suave = Color.FromArgb(28, 44, 69),
            SuaveHover = Color.FromArgb(36, 56, 90),
            SuaveTexto = Color.FromArgb(219, 229, 242),
            Perigo = Color.FromArgb(58, 29, 36),
            PerigoHover = Color.FromArgb(74, 34, 43),
            PerigoTexto = Color.FromArgb(255, 154, 154),
            Sucesso = Color.FromArgb(76, 194, 127),
            Etapa = Color.FromArgb(240, 144, 31),
            EtapaTexto = Color.FromArgb(26, 17, 4)
        };
    }
}