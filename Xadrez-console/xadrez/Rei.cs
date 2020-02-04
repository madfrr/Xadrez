using tabuleiro;

namespace xadrez
{
    class Rei : Peca
    {
        public Rei(Cor cor, Tabuleiro tab) : base(cor, tab) { }
        public override string ToString()
        {
            return "R";
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[tabuleiro.linhas, tabuleiro.colunas];

            Posicao pos = new Posicao(posicao.linha - 1, posicao.coluna - 1);

            for (int linha = posicao.linha - 1; linha < posicao.linha + 2; linha++)
            {
                for (int coluna = posicao.coluna - 1; coluna < posicao.coluna + 2; coluna++)
                {
                    pos.linha = linha;
                    pos.coluna = coluna;
                    if (PodeMover(pos))
                    {
                        mat[linha, coluna] = true;
                    }
                }
            }
            return mat;
        }
    }
}
