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
                    Console.WriteLine("Origem:");
                    Posicao origem = Tela.LerPosicaoXadrez();
                    Console.WriteLine("Destino:");
                    Posicao destino = Tela.LerPosicaoXadrez();
                    partida.ExecutaMovimento(origem, destino);
                }

            }
            catch(TabuleiroException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
