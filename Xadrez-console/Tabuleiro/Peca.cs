namespace tabuleiro
{
    class Peca
    {
        public Cor cor { get; set; }
        public Posicao posicao { get; protected set; }
        public Tabuleiro tabuleiro { get; protected set; }
        public int qteMovimentos { get; protected set; }

        public Peca (Cor cor, Posicao posicao, Tabuleiro tabuleiro)
        {
            this.cor = cor; 
            this.posicao = posicao; 
            this.tabuleiro = tabuleiro;
            qteMovimentos = 0;
        }
    }
}
