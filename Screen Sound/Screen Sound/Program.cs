// Screen Sound
string msg = ("Boas Vindas ao Screen Sound");
//List<string> lisBandas = new List<string>();

Dictionary<string, List<int>> bandasRegistrsdas = new Dictionary<string, List<int>>();


void exibirlogo()
{
    Console.WriteLine(@"
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░"
);
    Console.WriteLine( );
    Console.WriteLine(msg);
}

void menu()
{
    Console.Clear();
    exibirlogo();
    Console.WriteLine();
    Console.WriteLine("1 - para registrar banda");
    Console.WriteLine("2 - para mostrar todas as bandas");
    Console.WriteLine("3 - para avaliar uma banda");
    Console.WriteLine("4 - para exibir a média de uma banda");
    Console.WriteLine("5 - para sair");

    Console.Write("\nDigite a sua opção: ");
    string opc = Console.ReadLine()!;
    int opcNumerica = int.Parse(opc);

    switch (opcNumerica)
    {
        case 1: registrarBanda();
            break;
        case 2: mostrarBandas();
            break; 
        case 3: avaliarBanda();
            break;  
        case 4: Console.WriteLine("opção " + opcNumerica);
            break;
        case 5: Console.WriteLine("\nSaindo...");
            break; 
        default: Console.WriteLine("\nopção invalida!!");
            break;

    }
}

void registrarBanda()
{
    Console.Clear();
    exibirTitulo("Registro de bandas");
    Console.Write("Digite o nome da banda: ");
    string nomeBanda = Console.ReadLine()!;
    bandasRegistrsdas.Add(nomeBanda, new List<int>());
    Console.WriteLine($"A banda {nomeBanda} foi registrada com sucesso!");
    Console.ReadKey();
    menu(); 
}

void mostrarBandas()
{
    Console.Clear();
    exibirTitulo("Exibindo todas as bandas registradas");
    //for(int i = 0; i < lisBandas.Count; i++)
    //{
    //    Console.WriteLine($"Banda: {lisBandas[i]}");
    //}
    foreach(string banda in bandasRegistrsdas.Keys)
    {
        Console.WriteLine($"Banda: {banda}");
    }
    Console.ReadKey();
    menu();
}

void exibirTitulo(string titulo)
{
    int quantLetras = titulo.Length;
    string aster = string.Empty.PadLeft(quantLetras, '*');
    Console.WriteLine(aster);
    Console.WriteLine(titulo);
    Console.WriteLine(aster + "\n");
}

void avaliarBanda()
{
    Console.Clear();
    exibirTitulo("Avaliar banda");
    Console.Write("Qual banda voçê deseja avaliar: ");
    string nomeBanda = Console.ReadLine()!;
    if (bandasRegistrsdas.ContainsKey(nomeBanda))
    {
        Console.Write($"Qual a nota voçê da para {nomeBanda}: ");
        int nota = int.Parse(Console.ReadLine()!);
        bandasRegistrsdas[nomeBanda].Add(nota);
        Console.WriteLine("Nota Registrada");
        Console.ReadKey();
        menu();

    }
    else
    {
        Console.WriteLine($"\nA Banda {nomeBanda} não foi encontrada\n");
        Console.ReadKey();
        menu();
    }
}

menu();

