using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] nomes = new string[5];
            int op = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("1 - para adicionar 5 pessoas");
                Console.WriteLine("2 - para mostrar pessoas");
                Console.WriteLine("3 - para editar pessoa");
                Console.WriteLine("4 - para sair");
                op = int.Parse(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        Console.Clear();
                        for (int i = 0; i < 5; i++)
                        {
                            Console.Write($"{i + 1}° pessoa: ");
                            nomes[i] = Console.ReadLine();
                        }
                        break;

                    case 2:
                        Console.Clear();
                        for (int i = 0; i < 5; i++)
                        {
                            Console.Write($"{i + 1}° pessoa: {nomes[i]}\n");
                        }
                        Console.ReadKey();
                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine("Qual pessoa você deseja editar");
                        for (int i = 0; i < 5; i++)
                        {
                            Console.Write($"{i + 1} - {nomes[i]}\n");
                        }
                        Console.Write("\nResposta: ");
                        int edit = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                        Console.WriteLine($"editar o {nomes[edit -1]}");
                        Console.WriteLine();
                        Console.Write("Qual nome vai colocar no lugar: ");
                        nomes[edit - 1] = Console.ReadLine();
                        Console.WriteLine();
                        Console.WriteLine($"nome: {nomes[edit -1]} adicionado com sucesso!!");
                        Console.ReadKey();
                        break;

                    case 4:
                        Console.Clear();
                        Console.WriteLine("SAINDO...");
                        break;
                }
            } while (op != 4);
        }
    }
}
