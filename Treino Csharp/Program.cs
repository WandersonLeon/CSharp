// Screen Sound
// List<string> listaDasBandas = new List<string> { "The Beatles", "The Doors", "Rolling Stones", "Skank", "Detonautas" };
Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();
bandasRegistradas.Add("Link In Park", new List<int> { 10, 9, 2, 5, 3 });
bandasRegistradas.Add("The Beatles", new List<int>());
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

void ExibirTituloOpcao(string titulo)
{

    int quantidadeLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(quantidadeLetras, '*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");

}

void ExibirMenu()
{
    Console.Clear();
    ExibirLogo();
    ExibirTituloOpcao("Boas vindas ao Screen Sound !");
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
            AvaliarBandas();
            break;
        case "4":
            ExibirMedia();
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
    ExibirTituloOpcao("Registro de Bandas");
    Console.Write("Digite o nome da banda que deseja registrar:  ");

    //Le a entrada do usuario e adiciona ao dicionario bandasRegistradas
    string nomeDaBanda = Console.ReadLine()!;
    bandasRegistradas.Add(nomeDaBanda, new List<int>());
    Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!");

    //Da escolha para o usuario registrar outra banda.
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
    ExibirTituloOpcao("Exibindo todas as bandas !");

    //Foreach para exibir todas as bandas no Dicionario bandasRegistradas
    foreach (string banda in bandasRegistradas.Keys)
    {
        Console.WriteLine($"Banda: {banda}");
    }

    //Opção para voltar ao MENU
    Console.WriteLine("Pressione ENTER para voltar ao MENU");
    var escolha = Console.ReadKey(true);
    if (escolha.Key == ConsoleKey.Enter)
    {
        ExibirMenu();
    }
    else
    {
        MostrarBandas();
    }

}

void AvaliarBandas()
{
    Console.Clear();
    ExibirTituloOpcao("Avaliar Banda");
    Console.Write("Informe a banda que deseja avaliar: ");
    string bandaEscolhida = Console.ReadLine()!;

    // Testa se a bandaEscolhida existe no dicionário de bandasRegistradas.
    if (bandasRegistradas.ContainsKey(bandaEscolhida))
    {
        int nota = 0;

        // Enquanto a nota não for válida, o código continua pedindo para o usuário digitar.
        while (true)
        {
            Console.Write($"De 1 a 5, qual a nota para a banda {bandaEscolhida}? ");
            string entrada = Console.ReadLine();

            // Tenta converter a string de entrada em um número inteiro.
            if (int.TryParse(entrada, out nota) && nota >= 1 && nota <= 5)
            {
                bandasRegistradas[bandaEscolhida].Add(nota);
                Console.WriteLine($"\nA nota {nota} foi registrada com sucesso!");
                Thread.Sleep(1500);
                ExibirMenu();
            }
            else
            {
                Console.WriteLine("Nota inválida! Insira um valor entre 1 e 5.");
                Thread.Sleep(1500);
            }
        }
    }
    else
    {
        Console.WriteLine($"\nA banda {bandaEscolhida} não foi encontrada!");
        Console.WriteLine("Pressione ENTER para retornar ao menu e registrá-la!");
        var escolha = Console.ReadKey(true);
        if (escolha.Key == ConsoleKey.Enter)
        {
            ExibirMenu();
        }
        else
        {
            AvaliarBandas();
        }
    }

}

void ExibirMedia()
{
    Console.Clear();
    ExibirTituloOpcao("Média da Banda");
    Console.Write("Informe a banda que deseja visualizar a média: ");
    string bandaEscolhida = Console.ReadLine()!;
    double media;
    // Testa se a bandaEscolhida existe no dicionário de bandasRegistradas.
    if (bandasRegistradas.ContainsKey(bandaEscolhida))
    {
        List<int> notasDaBanda = bandasRegistradas[bandaEscolhida];
        Console.WriteLine($"A banda {bandaEscolhida} possui {notasDaBanda.Average()} de 5 pontos.");
        Console.WriteLine("Pressione uma tecla para retornar ao MENU");
        Console.ReadKey();
        Console.Clear();
        ExibirMenu();
    }
    else
    {
        Console.WriteLine($"\nA banda {bandaEscolhida} não foi encontrada!");
        Console.WriteLine("Pressione ENTER para retornar ao menu e registrá-la!");
        var escolha = Console.ReadKey(true);
        if (escolha.Key == ConsoleKey.Enter)
        {
            ExibirMenu();
        }
        else
        {
            ExibirMedia();
        }
    }


}