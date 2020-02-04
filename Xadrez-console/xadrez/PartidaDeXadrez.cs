using System;
using System.Collections.Generic;
using tabuleiro;

namespace xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro tab { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool terminada { get; private set; }
        private HashSet<Peca> pecas;
        private HashSet<Peca> pecasCapturadas;
        public PartidaDeXadrez()
        {
            tab = new Tabuleiro(8, 8);
            terminada = false;
            turno = 1;
            pecas = new HashSet<Peca>();
            pecasCapturadas = new HashSet<Peca>();
            jogadorAtual = Cor.Branco;
            ColocarPecas();
        }

        public void ValidaPosicaoOrigem(Posicao pos)
        {
            if (tab.peca(pos) == null)
            {
                throw new TabuleiroException("Nao existe peca nessa posicao");
            }
            if (jogadorAtual != tab.peca(pos).cor)
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
            if (pecaCapturada != null)
            {
                pecasCapturadas.Add(pecaCapturada);
            }
        }
        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            ExecutaMovimento(origem, destino);
            turno++;
            TrocaJogador();
        }

        private void TrocaJogador()
        {
            if (jogadorAtual == Cor.Branco)
            {
                jogadorAtual = Cor.Preto;
            }
            else
            {
                jogadorAtual = Cor.Branco;
            }
        }

        public HashSet<Peca> PecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach(Peca p in pecasCapturadas)
            {
                if (p.cor == cor) aux.Add(p);
            }
            return aux;
        }

        public HashSet<Peca> PecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>(pecas);
            aux.ExceptWith(PecasCapturadas(cor));
            return aux;
        }

        public void ColocarNovaPeca(char coluna, int linha, Peca peca)
        {
            tab.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
            pecas.Add(peca);
        }

        private void ColocarPecas()
        {
            ColocarNovaPeca('d', 1, new Rei(Cor.Branco, tab));
            ColocarNovaPeca('c', 1, new Torre(Cor.Branco, tab));
            ColocarNovaPeca('c', 2, new Torre(Cor.Branco, tab));
            ColocarNovaPeca('e', 1, new Torre(Cor.Branco, tab));
            ColocarNovaPeca('e', 2, new Torre(Cor.Branco, tab));
            ColocarNovaPeca('d', 2, new Torre(Cor.Branco, tab));

            ColocarNovaPeca('d', 8, new Rei(Cor.Preto, tab));
            ColocarNovaPeca('c', 7, new Torre(Cor.Preto, tab));
            ColocarNovaPeca('e', 7, new Torre(Cor.Preto, tab));
            ColocarNovaPeca('c', 8, new Torre(Cor.Preto, tab));
            ColocarNovaPeca('e', 8, new Torre(Cor.Preto, tab));
            ColocarNovaPeca('d', 7, new Torre(Cor.Preto, tab));
        }
    }
}
