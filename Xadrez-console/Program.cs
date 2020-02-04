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
                    try
                    {
                        Console.Clear();
                        Tela.imprimirTabuleiro(partida.tab);
                        Console.WriteLine();
                        Console.WriteLine("Turno: " + partida.turno);
                        Console.WriteLine("Jogador atual: " + partida.jogadorAtual);
                        Console.WriteLine();
                        Console.WriteLine("Origem:");
                        Posicao origem = Tela.LerPosicaoXadrez();
                        partida.ValidaPosicaoOrigem(origem);

                        Console.Clear();
                        bool[,] posicoesPossiveis = partida.tab.peca(origem).MovimentosPossiveis();
                        Tela.imprimirTabuleiro(partida.tab, posicoesPossiveis);

                        Console.WriteLine();
                        Console.WriteLine("Turno: " + partida.turno);
                        Console.WriteLine("Jogador atual: " + partida.jogadorAtual);
                        Console.WriteLine();
                        Console.WriteLine("Destino:");
                        Posicao destino = Tela.LerPosicaoXadrez();
                        partida.ValidaPosicaoDestino(origem, destino);
                        partida.RealizaJogada(origem, destino);
                    }
                    catch(TabuleiroException ex)
                    {
                        Console.WriteLine(ex.Message + ". Aperte enter para continuar...");
                        Console.ReadLine();
                    }

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
