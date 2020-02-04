namespace tabuleiro
{
    abstract class Peca
    {
        public Cor cor { get; protected set; }
        public Posicao posicao { get;  set; }
        public Tabuleiro tabuleiro { get; protected set; }
        public int qtdMovimentos { get; protected set; }

        public Peca (Cor cor, Tabuleiro tabuleiro)
        {
            this.cor = cor; 
            this.posicao = null; 
            this.tabuleiro = tabuleiro;
            qtdMovimentos = 0;
        }

        protected bool PodeMover(Posicao pos)
        {
            if (!tabuleiro.PosicaoValida(pos)) return false;
            return !tabuleiro.existePeca(pos) || tabuleiro.peca(pos).cor != cor;
        }

        public void IncrementaQtdMovimentos()
        {
            qtdMovimentos++;
        }
        public abstract bool[,] MovimentosPossiveis();
    }
}
