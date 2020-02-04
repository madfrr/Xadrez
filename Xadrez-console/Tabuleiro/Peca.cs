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
        public bool ExisteMovimentosPossiveis()
        {
            bool[,] mat = MovimentosPossiveis();
            for(int i=0; i<tabuleiro.linhas; i++)
            {
                for(int j=0; j<tabuleiro.colunas; j++)
                {
                    if (mat[i, j]) return true;
                }
            }
            return false;
        }
        public bool PodeMoverPara(Posicao destino)
        {
            return MovimentosPossiveis()[destino.linha, destino.coluna];
        }
        public abstract bool[,] MovimentosPossiveis();
    }
}
