using System;
using tabuleiro;

namespace xadrez
{
    class PosicaoXadrez
    {
        public int linha { get; set; }
        public char coluna { get; set; }
        public PosicaoXadrez(int linha, char coluna)
        {
            this.linha = linha;
            this.coluna = coluna;
        }
        public Posicao ToPosicao()
        {
            return new Posicao(8 - linha, 'a' - coluna);
        }
        public override string ToString()
        {
            return "" + coluna + linha;
        }
    }
}
