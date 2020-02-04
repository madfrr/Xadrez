using tabuleiro;

namespace xadrez
{
    class Torre : Peca
    {
        public Torre(Cor cor, Tabuleiro tab) : base(cor, tab) { }
        public override string ToString()
        {
            return "T";
        }
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[tabuleiro.linhas, tabuleiro.colunas];

            Posicao pos = new Posicao(posicao.linha - 1, posicao.coluna);

            //testar pra cima
            while (PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if(tabuleiro.peca(pos)!=null &&tabuleiro.peca(pos).cor != cor)
                {
                    break;
                }
                pos.linha = pos.linha - 1;
            }

            pos.linha = posicao.linha +1; 
            pos.coluna = posicao.coluna;
            //pra baixo
            while (PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor)
                {
                    break;
                }
                pos.linha = pos.linha + 1;
            }

            pos.linha = posicao.linha;
            pos.coluna = posicao.coluna - 1;
            //pro lado
            while (PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor)
                {
                    break;
                }
                pos.coluna = pos.coluna - 1;
            }

            pos.linha = posicao.linha;
            pos.coluna = posicao.coluna + 1;
            //pro outro
            while (PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor)
                {
                    break;
                }
                pos.coluna = pos.coluna + 1;
            }
            return mat;
        }

    }
}
