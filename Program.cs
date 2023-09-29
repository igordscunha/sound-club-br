
Dictionary<string, List<bool>> Participantes = new Dictionary<string, List<bool>>
{
    { "Bruno Almeida", new List<bool> { true } },
    { "Luiza Santos", new List<bool> { false } }
};
void ExibirLogo()
{
    Console.WriteLine(@"    
██████████████████████████████████████████████████████████████████████████
█─▄▄▄▄█─▄▄─█▄─██─▄█▄─▀█▄─▄█▄─▄▄▀███─▄▄▄─█▄─▄███▄─██─▄█▄─▄─▀███▄─▄─▀█▄─▄▄▀█
█▄▄▄▄─█─██─██─██─███─█▄▀─███─██─███─███▀██─██▀██─██─███─▄─▀████─▄─▀██─▄─▄█
▀▄▄▄▄▄▀▄▄▄▄▀▀▄▄▄▄▀▀▄▄▄▀▀▄▄▀▄▄▄▄▀▀▀▀▄▄▄▄▄▀▄▄▄▄▄▀▀▄▄▄▄▀▀▄▄▄▄▀▀▀▀▄▄▄▄▀▀▄▄▀▄▄▀
");

    ExibirTituloDaOpcao("Bem vindo ao SOUND CLUB BR");
}


void Menu()
{
    ExibirLogo();    
    Console.WriteLine("Digite 1 se você quer registrar um participante.");
    Console.WriteLine("Digite 2 se você quer ver todos os participantes da festa.");
    Console.WriteLine("Digite 3 se você quer verificar o status do participante.");
    Console.WriteLine("Digite 0 se você quiser sair.");
    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    switch (opcaoEscolhidaNumerica)
    {
        case 1: RegistrarParticipante();
            break;
        case 2: MostrarParticipantes();
            break;
        case 3: MudarStatus();
            break;
        case 0: Console.WriteLine("Bye bye ;)");
            break;
        default: Console.WriteLine("Opção inválida");
            break;
    }
}


void RegistrarParticipante()
{
    Console.Clear();
    ExibirTituloDaOpcao("Registre um participante");
    Console.Write("Digite o nome do participante que deseja registrar: ");
    string nomeDaParticipante = Console.ReadLine()!;
    Participantes.Add(nomeDaParticipante, new List<bool>());
    Console.WriteLine($"Participante {nomeDaParticipante} registrado(a) com sucesso!\n");
    Console.WriteLine($"Digite 1 se a situação do(a) {nomeDaParticipante} está paga.");
    Console.WriteLine($"Digite 2 se a situação do(a) {nomeDaParticipante} está aguardando pagamento.");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoNumerica = int.Parse(opcaoEscolhida);

    switch (opcaoNumerica)
    {
        case 1: 
            Participantes[nomeDaParticipante].Add(true);
                break;
        case 2:
            Participantes[nomeDaParticipante].Add(false);
                break;
    }

    Console.WriteLine("\nObrigado. Você voltará ao menu principal em breve.");
    Thread.Sleep(3400);
    Console.Clear();
    Menu();
}


void MostrarParticipantes()
{
    Console.Clear();
    ExibirTituloDaOpcao("Participantes registradas e seus respectivos status");
    string statusConfirmado;

    foreach(var participante in Participantes)
    {
        string nome = participante.Key;
        List<bool> status = participante.Value!;
        bool statusPessoa = status[0];

        if (statusPessoa == true)
        {
            statusConfirmado = "pago";
        }
        else
        {
            statusConfirmado = "aguardando pagamento";
        }

        Console.Write($"O(A) participante: {participante.Key} está com o status: {statusConfirmado}.\n");
    }
  
    Console.WriteLine("\nDigite qualquer tecla para voltar ao menu principal.");
    Console.ReadKey();
    Console.Clear();
    Menu();
}

void MudarStatus()
{
    Console.Clear();
    ExibirTituloDaOpcao("Mude o status do pagamento de um participante");
    Console.Write("Digite o nome do(a) participante: ");
    string nomeDaParticipante = Console.ReadLine()!;
    if (Participantes.Keys.Contains(nomeDaParticipante))
    {
        Console.WriteLine($"\nDigite 1 para mudar o status do(a) {nomeDaParticipante} para pago.");
        Console.WriteLine($"Digite 2 para mudar o status do(a) {nomeDaParticipante} para extornado.");
        Console.WriteLine($"Digite 3 para mudar o status do(a) {nomeDaParticipante} para cortesia.");
        Console.WriteLine($"Digite 4 para mudar o status do(a) {nomeDaParticipante} para aguardando pagamento.");
        int opcaoEscolhida = int.Parse(Console.ReadLine()!);

        switch (opcaoEscolhida) 
        {
            case 1:
                Participantes[nomeDaParticipante][0] = true;
                    break;
            case 2:
                Participantes[nomeDaParticipante][0] = false;
                    break;
            case 3:
                Participantes[nomeDaParticipante][0] = true;
                    break;
            case 4:
                Participantes[nomeDaParticipante][0] = false;
                    break;
        }

        Console.WriteLine("\nStatus editado com sucesso! Você retornará ao menu principal em instantes...");
        Thread.Sleep(3400);
        Console.Clear();
        Menu();
    } else
    {
        Console.WriteLine("\nEssa participante ainda não foi registrado");
        Console.WriteLine("\nDigite qualquer tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        Menu();
    }
}

void ExibirTituloDaOpcao(string titulo)
{
    int tamanhoDoTitulo = titulo.Length;
    string asteriscos = string.Empty.PadLeft(tamanhoDoTitulo, '*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo.ToUpper());
    Console.WriteLine(asteriscos + "\n");
}



Menu();