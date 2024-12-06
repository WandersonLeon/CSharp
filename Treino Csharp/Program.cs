// Screen Sound
List<string> listaDasBandas = new List<string>{ "The Beatles","The Doors", "Rolling Stones", "Skank", "Detonautas"};
Console.Clear();
ExibirMenu();

void ExibirLogo()
{
    Console.WriteLine(@"
█████████████████████████████████████████████████████████████████████████
█─▄▄▄▄█─▄▄▄─█▄─▄▄▀█▄─▄▄─█▄─▄▄─█▄─▀█▄─▄███─▄▄▄▄█─▄▄─█▄─██─▄█▄─▀█▄─▄█▄─▄▄▀█
█▄▄▄▄─█─███▀██─▄─▄██─▄█▀██─▄█▀██─█▄▀─████▄▄▄▄─█─██─██─██─███─█▄▀─███─██─█
▀▄▄▄▄▄▀▄▄▄▄▄▀▄▄▀▄▄▀▄▄▄▄▄▀▄▄▄▄▄▀▄▄▄▀▀▄▄▀▀▀▄▄▄▄▄▀▄▄▄▄▀▀▄▄▄▄▀▀▄▄▄▀▀▄▄▀▄▄▄▄▀▀");
    Console.WriteLine("\n");
}
void ExibirMenu()
{
    Console.Clear();
    ExibirLogo();
    Console.WriteLine("Boas vindas ao Screen Sound ! \n");
    Console.WriteLine("Digite 1 para registrar uma banda.");
    Console.WriteLine("Digite 2 para mostrar todas as bandas.");
    Console.WriteLine("Digite 3 para avaliar uma banda.");
    Console.WriteLine("Digite 4 para exibir a média de uma banda.");
    Console.WriteLine("Digite 0 para SAIR!!");
    Console.Write("Escolha UMA opção:   ");
    var respMenu = Console.ReadLine()!;
    switch (respMenu)
    {
        case "1":
            RegistrarBanda();
            break;
        case "2":
            MostrarBandas();
            break;
        case "3":
            Console.WriteLine("Você escolheu a opção 3!!");
            break;
        case "4":
            Console.WriteLine("Você escolheu a opção 4!!");
            break;
        case "0":
            Console.WriteLine("Você escolheu SAIR!!");
            break;
        default:
            Console.Clear();
            break;
            ExibirMenu();
    }

}

void RegistrarBanda()
{
    Console.Clear();
    Console.WriteLine("Registro de Bandas\n");
    Console.Write("Digite o nome da banda que deseja registrar:  ");
    string nomeDaBanda = Console.ReadLine()!;
    listaDasBandas.Add(nomeDaBanda);
    Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!");
    Console.WriteLine("Deseja Registrar outra banda ? [S/N] ");
    string outraBanda = Console.ReadLine();
    if (outraBanda.ToUpper() == "S" || outraBanda.ToUpper() == "SIM")
    {
        RegistrarBanda();
    }
    Thread.Sleep(1400);
    Console.Clear();
    ExibirMenu();

}

void MostrarBandas()
{
    Console.Clear();
    ExibirLogo();
    Console.WriteLine("Todas as Bandas \n");


    foreach (string banda in listaDasBandas){
        Console.WriteLine($"Banda: {banda}");
    }
    // for (int i = 0; i < listaDasBandas.Count; i++)
    // {
    //     Console.WriteLine($"Banda: {listaDasBandas[i]}");
    // }
    Console.WriteLine("Pressione ENTER para voltar ao MENU");
    var escolha = Console.ReadKey(true);
    if (escolha.Key == ConsoleKey.Enter)
    {
        ExibirMenu();
    }
    else
    {
        Console.Clear();
        MostrarBandas();
    }

}

