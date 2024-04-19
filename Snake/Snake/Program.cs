using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    internal class Program
    {
        const int larguraTela = 60;
        const int alturaTela = 29;
        const string corpoCobra = "■";

        static string[,] tela = new string[larguraTela, alturaTela];
        static bool jogoRodando = true;
        static List<Coordenada> coordenadasCobra = new List<Coordenada>();
        static Direcao direcao = Direcao.Direita;
        static int placar = 0;
        static Random rand = new Random();

        static void Main(string[] args)
        {
            IniciarJogo();
        }

        static void IniciarJogo()
        {
            CriarCobra();
            CriarComida();
            LerTeclas();

            while (jogoRodando)
            {
                Thread.Sleep(50);
                MoverCobra();
                RenderizarCobra();
            }

            FimJogo();
        }

        static void CriarCobra()
        {
            coordenadasCobra.Add(new Coordenada(9, 14));
            coordenadasCobra.Add(new Coordenada(8, 14));
            coordenadasCobra.Add(new Coordenada(7, 14));

            AtualizarPosicao();
        }

        static void AtualizarPosicao()
        {
            for(int i = 0; i < larguraTela; i++)
            {
                for(int j = 0; j < alturaTela; j++)
                {
                    var posicaoConterCobra = coordenadasCobra.Any(coordenada => coordenada.x == i && coordenada.y == j);

                    if (posicaoConterCobra)
                    {
                        tela[i, j] = corpoCobra;
                        continue;
                    }

                    if (tela[i, j] == corpoCobra)
                    {
                        tela[i, j] = " ";
                    }
                }
            }
        }

        static void CriarComida()
        {
            int aleatorioX, aleatorioY;
            Random random = new Random();

            do
            {
                aleatorioX = random.Next(0, larguraTela);
                aleatorioY = random.Next(0, alturaTela);
            } while (tela[aleatorioX, aleatorioY] == corpoCobra);

            tela[aleatorioX, aleatorioY] = "@";
        }

        static void LerTeclas()
        {
            Thread task = new Thread(LerAcaoTeclas);
            task.Start();
        }

        static void LerAcaoTeclas()
        {
            while (jogoRodando)
            {
                var tecla = Console.ReadKey();

                if(tecla.Key == ConsoleKey.UpArrow && direcao != Direcao.Baixo)
                {
                    direcao = Direcao.Cima;
                }

                if(tecla.Key == ConsoleKey.DownArrow && direcao != Direcao.Cima)
                {
                    direcao = Direcao.Baixo;
                }

                if(tecla.Key == ConsoleKey.LeftArrow && direcao != Direcao.Direita)
                {
                    direcao = Direcao.Esquerda;
                }

                if(tecla.Key == ConsoleKey.RightArrow && direcao != Direcao.Esquerda)
                {
                    direcao = Direcao.Direita;
                }
            }
        }

        static void MoverCobra()
        {
            var cabeca = coordenadasCobra[0];
            var coordenadaRaboX = coordenadasCobra[1].x;
            var coordenadaRaboY = coordenadasCobra[1].y;

            for(int i = coordenadasCobra.Count - 1; i > 0; i--)
            {
                coordenadasCobra[i].x = coordenadasCobra[i -1].x;
                coordenadasCobra[i].y = coordenadasCobra[i - 1].y;
            }

            if(direcao == Direcao.Direita)
            {
                cabeca.x++;

                if(cabeca.x > larguraTela - 1)
                {
                    cabeca.x = 0;
                }
            }

            if(direcao == Direcao.Esquerda)
            {
                cabeca.x--;

                if(cabeca.x < 0)
                {
                    cabeca.x = larguraTela - 1;
                }
            }

            if(direcao == Direcao.Cima)
            {
                cabeca.y--;

                if(cabeca.y < 0)
                {
                    cabeca.y = alturaTela - 1;
                }
            }

            if(direcao == Direcao.Baixo)
            {
                cabeca.y++;

                if(cabeca.y > alturaTela - 1)
                {
                    cabeca.y = 0;
                }
            }

            if (tela[cabeca.x, cabeca.y] == "@")
            {
                placar += rand.Next(1, 10);
                coordenadasCobra.Add(new Coordenada(coordenadaRaboX, coordenadaRaboY));
                CriarComida();
            }

            if (tela[cabeca.x, cabeca.y] == corpoCobra)
            {
                jogoRodando = false;
                return;
            }

            AtualizarPosicao();
        }

        static void RenderizarCobra()
        {
            Console.Clear();
            var telaRenderizada = "";

            for (int j = 0; j < alturaTela; j++)
            {
                for (int i = 0; i < larguraTela; i++)
                {
                    if(tela[i, j] != null && tela[i, j] != " ")
                    {
                        telaRenderizada += tela[i, j];
                    }
                    else
                    {
                        telaRenderizada += " ";
                    }
                }

                telaRenderizada += "\n";
            }
            Console.Write(telaRenderizada);
        }

        static void FimJogo()
        {
            Console.Clear();
            Console.WriteLine($"FIM DE JOGO!! sua pontuação foi: {placar}");
        }
    }
}
