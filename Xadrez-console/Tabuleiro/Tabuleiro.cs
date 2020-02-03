namespace tabuleiro
{
    class Tabuleiro
    {
        public int linhas { get; set; }
        public int colunas { get; set; }
        private Peca[,] pecas;

        public Tabuleiro(int linhas, int colunas)
        {
            this.linhas = linhas;
            this.colunas = colunas;
            pecas = new Peca[linhas, colunas];
        }
        public Peca peca(int i, int j)
        {
            return pecas[i, j];
        }
        public void ColocarPeca(Peca peca, Posicao posicao)
        {
            pecas[posicao.linha, posicao.coluna] = peca;
            peca.posicao = posicao;
        }
        
    }
}
