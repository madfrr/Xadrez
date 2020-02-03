using System;
using tabuleiro;

namespace xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro tab { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool terminada { get; private set; }

        public PartidaDeXadrez()
        {
            tab = new Tabuleiro(8, 8);
            ColocarPecas();
            terminada = false;
            turno = 1;
            jogadorAtual = Cor.Branco;
        }

        public void ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tab.RetirarPeca(origem);
            p.IncrementaQtdMovimentos();
            Peca pecaCapturada = tab.RetirarPeca(destino);
            tab.ColocarPeca(p, destino);
        }

        private void ColocarPecas()
        {
            tab.ColocarPeca(new Rei(Cor.Branco, tab), new PosicaoXadrez('d',1).ToPosicao());
            tab.ColocarPeca(new Torre(Cor.Branco, tab), new PosicaoXadrez('c', 1).ToPosicao());
            tab.ColocarPeca(new Torre(Cor.Branco, tab), new PosicaoXadrez('e', 1).ToPosicao());
            tab.ColocarPeca(new Torre(Cor.Branco, tab), new PosicaoXadrez('c', 2).ToPosicao());
            tab.ColocarPeca(new Torre(Cor.Branco, tab), new PosicaoXadrez('e', 2).ToPosicao());
            tab.ColocarPeca(new Torre(Cor.Branco, tab), new PosicaoXadrez('d', 2).ToPosicao());

            tab.ColocarPeca(new Rei(Cor.Preto, tab), new PosicaoXadrez('d', 8).ToPosicao());
            tab.ColocarPeca(new Torre(Cor.Preto, tab), new PosicaoXadrez('c', 7).ToPosicao());
            tab.ColocarPeca(new Torre(Cor.Preto, tab), new PosicaoXadrez('e', 7).ToPosicao());
            tab.ColocarPeca(new Torre(Cor.Preto, tab), new PosicaoXadrez('c', 8).ToPosicao());
            tab.ColocarPeca(new Torre(Cor.Preto, tab), new PosicaoXadrez('e', 8).ToPosicao());
            tab.ColocarPeca(new Torre(Cor.Preto, tab), new PosicaoXadrez('d', 7).ToPosicao());
        }
    }
}
