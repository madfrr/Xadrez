namespace tabuleiro
{
    class Peca
    {
        public Cor cor { get; protected set; }
        public Posicao posicao { get;  set; }
        public Tabuleiro tabuleiro { get; protected set; }
        public int qteMovimentos { get; protected set; }

        public Peca (Cor cor, Tabuleiro tabuleiro)
        {
            this.cor = cor; 
            this.posicao = null; 
            this.tabuleiro = tabuleiro;
            qteMovimentos = 0;
        }
    }
}
