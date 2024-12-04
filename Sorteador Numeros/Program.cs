Random geradorDeNumeros = new Random();
bool jogarNovamente = true;
Console.Clear();

// Laço de repetição para continuar o jogo
while (jogarNovamente)
{
    int numeroAleatorio = geradorDeNumeros.Next(1, 101);

    Jogo(numeroAleatorio);

    Console.WriteLine("O jogo acabou, quer tentar novamente? [S/N]");
    string resposta = Console.ReadLine();

    //Utilizei o ToUpper() para evitar confusão entre minuculas e maiusculas, mas sei que tem outras formas melhores.

    jogarNovamente = (resposta.ToUpper() == "S" || resposta.ToUpper() == "SIM");
}

void Jogo(int numeroAleatorio)
{
    int chuteNum;

    do
    {
        Console.WriteLine("Adivinhe o número que estou pensando, entre 1 e 100.");

        // Tryparse para evitar possiveis erros na entrada.
        if (!int.TryParse(Console.ReadLine(), out chuteNum) || chuteNum < 1 || chuteNum > 100)
        {
            Console.WriteLine("Por favor, insira um número válido entre 1 e 100.");
            continue;
            /* Dessa forma a mensagem aparece e logo em seguida continua, também fiz com Console.Clear(),
            mas fica resetando a pagina, creio que não seja uma boa experiencia.
            */
        }

        // Comparação do chute com o número sorteado.
        switch (chuteNum.CompareTo(numeroAleatorio))
        {
            case 0:
                Console.WriteLine($"Parabéns, {chuteNum} era o número sorteado!!!");
                return;
            case -1:
                Console.WriteLine($"Ainda não, {chuteNum} é menor do que o número sorteado.");
                break;
            case 1:
                Console.WriteLine($"Ainda não, {chuteNum} é maior do que o número sorteado.");
                break;
        }
    } while (true);
}
