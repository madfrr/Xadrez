namespace tabuleiro
{
    class Tabuleiro
    {
        public int linhas { get; private set; }
        public int colunas { get; private set; }
        private Peca[,] pecas;

        public Tabuleiro(int linhas, int colunas)
        {
            this.linhas = linhas;
            this.colunas = colunas;
            pecas = new Peca[linhas, colunas];
        }

        public Peca peca(int i, int j)
        {
            return pecas[i, j];
        }

        public Peca peca(Posicao pos)
        {
            return pecas[pos.linha, pos.coluna];
        }
        
        public void ColocarPeca(Peca peca, Posicao posicao)
        {
            if (existePeca(posicao))
            {
                throw new TabuleiroException("Ja existe peca nessa posicao");
            }
            pecas[posicao.linha, posicao.coluna] = peca;
            peca.posicao = posicao;
        }
        public Peca RetirarPeca(Posicao posicao)
        {
            if (peca(posicao) == null) return null;
            Peca aux = peca(posicao);
            aux.posicao = null;
            pecas[posicao.linha, posicao.coluna] = null;
            return aux;
        }

        public bool existePeca(Posicao pos) 
        {
            ValidarPosicao(pos);
            return peca(pos) != null;
        }

        // na minha opiniao, nao precisava de dois metodos para validar posicao
        public bool PosicaoValida(Posicao pos)
        {
            if(pos.linha<0 || pos.linha >= linhas || pos.coluna<0 || pos.coluna >= colunas)
            {
                return false;
            }
            return true;
        }

        public void ValidarPosicao(Posicao pos)
        {
            if (!PosicaoValida(pos))
            {
                throw new TabuleiroException("Posicao invalida");
            }
        }
    }
}
