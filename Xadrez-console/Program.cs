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
                PartidaDeXadrez partida = new PartidaDeXadrez();

                while (!partida.terminada)
                {
                    Console.Clear();
                    Tela.imprimirTabuleiro(partida.tab);
                    Console.WriteLine();
                    Console.WriteLine("Origem:");
                    Posicao origem = Tela.LerPosicaoXadrez();

                    Console.Clear();
                    bool[,] posicoesPossiveis = partida.tab.peca(origem).MovimentosPossiveis();
                    Tela.imprimirTabuleiro(partida.tab, posicoesPossiveis);

                    Console.WriteLine();
                    Console.WriteLine("Destino:");
                    Posicao destino = Tela.LerPosicaoXadrez();
                    partida.ExecutaMovimento(origem, destino);
                }

            }
            catch (TabuleiroException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
