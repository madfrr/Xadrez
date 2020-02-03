using System;
using tabuleiro;
using xadrez;

namespace Xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Tabuleiro t = new Tabuleiro(8, 8);
                t.ColocarPeca(new Rei(Cor.Branco, t), new Posicao(1, 2));
                t.ColocarPeca(new Torre(Cor.Preto, t), new Posicao(3, 4));
                t.ColocarPeca(new Torre(Cor.Preto, t), new Posicao(5, 6));
                Tela.imprimirTabuleiro(t);
            }
            catch(TabuleiroException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
