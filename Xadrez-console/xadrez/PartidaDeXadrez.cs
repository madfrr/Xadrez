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

        public void ValidaPosicaoOrigem(Posicao pos)
        {
            if (tab.peca(pos) == null)
            {
                throw new TabuleiroException("Nao existe peca nessa posicao");
            }
            if(jogadorAtual != tab.peca(pos).cor)
            {
                throw new TabuleiroException("A peca de origem escolhida nao eh sua");
            }
            if (!tab.peca(pos).ExisteMovimentosPossiveis())
            {
                throw new TabuleiroException("Nao existe movimentos possiveis com essa peca");
            }
        }

        public void ValidaPosicaoDestino(Posicao origem, Posicao destino)
        {
            if (!tab.peca(origem).PodeMoverPara(destino))
            {
                throw new TabuleiroException("Posicao de destino Invalida");
            }

        }

        private void ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tab.RetirarPeca(origem);
            p.IncrementaQtdMovimentos();
            Peca pecaCapturada = tab.RetirarPeca(destino);
            tab.ColocarPeca(p, destino);
        }
        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            ExecutaMovimento(origem, destino);
            turno++;
            TrocaJogador();
        }

        private void TrocaJogador()
        {
            if(jogadorAtual == Cor.Branco)
            {
                jogadorAtual = Cor.Preto;
            }
            else
            {
                jogadorAtual = Cor.Branco;
            }
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
