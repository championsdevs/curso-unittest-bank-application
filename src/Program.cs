using BankApplication.Services;

var contaBancariaService = new ContaBancariaService();

while (true)
{
    Console.WriteLine("\nO que deseja fazer?\n");
    Console.WriteLine("1 - Cadastrar conta");
    Console.WriteLine("2 - Depositar");
    Console.WriteLine("3 - Sacar");
    Console.WriteLine("4 - Obter as contas cadastradas");
    Console.WriteLine("5 - Transferir");
    Console.WriteLine("6 - Encerrar conta");
    Console.WriteLine("0 - Sair");

    Console.Write("\nDigite uma opção: ");
    var input = Console.ReadLine();

    switch (input)
    {
        case "1":
            LogSeparador();
            CadastrarConta();
            LogSeparador();
            break;
        case "2":
            LogSeparador();
            Depositar();
            LogSeparador();
            break;
        case "3":
            LogSeparador();
            Sacar();
            LogSeparador();
            break;
        case "4":
            LogSeparador();
            ObterContas();
            LogSeparador();
            break;
        case "5":
            LogSeparador();
            RealizarTransferencia();
            LogSeparador();
            break;
        case "6":
            LogSeparador();
            EncerrarConta();
            LogSeparador();
            break;
        case "0":
            return;
        default:
            Console.WriteLine($"O comando digitado ({input}) não é válido.");
            continue;
    }

    Console.WriteLine("Digite qualquer tecla para voltar ao menu principal.");
    Console.ReadLine();
}

void CadastrarConta()
{
    Console.Write("\nDigite o nome do titular da conta: ");
    var titular = ObterEConverterValorDigitado<string>();

    var contaBancaria = contaBancariaService.CadastrarConta(titular);

    Console.WriteLine($"Conta cadastrada com sucesso para o titular {titular}. O id da conta é o {contaBancaria.Id}.");
}

void Depositar()
{
    Console.Write("Digite o id da conta: ");
    var contaId = ObterEConverterValorDigitado<int>();

    Console.Write("Digite o valor a ser depositado: R$ ");
    var valorDeposito = ObterEConverterValorDigitado<decimal>();

    try
    {
        var saldoDaConta = contaBancariaService.Depositar(contaId, valorDeposito);
        Console.WriteLine($"Depósito realizado. O saldo atual da conta é R$ {saldoDaConta}.");
    }
    catch (ContaNaoEncontradaException)
    {
        Console.WriteLine($"Não foi encontrada uma conta para o ID {contaId}. Por favor, tente novamente.");
        Depositar();
    }
}

void Sacar()
{
    Console.Write("Digite o id da conta: ");
    var contaId = ObterEConverterValorDigitado<int>();

    Console.Write("Digite o valor a ser sacado: R$ ");
    var valorSaque = ObterEConverterValorDigitado<decimal>();

    try
    {
        var saldoDaConta = contaBancariaService.Sacar(contaId, valorSaque);
        Console.WriteLine($"Saque realizado. O saldo atual da conta é R$ {saldoDaConta}.");
    }
    catch (ContaNaoEncontradaException)
    {
        Console.WriteLine($"Não foi encontrada uma conta para o ID {contaId}. Por favor, tente novamente.");
        Sacar();
    }
    catch (SaldoInsuficienteException)
    {
        Console.WriteLine($"O saldo não é suficiente para realizar um saque de {valorSaque}. Tente novamente.");
        Sacar();
    }
}

void ObterContas()
{
    var contasCadastradas = contaBancariaService.ObterContas();

    if (!contasCadastradas.Any())
    {
        Console.WriteLine("Nenhuma conta encontrada.");
        return;
    }

    Console.WriteLine("Conta cadastradas:");

    foreach (var conta in contasCadastradas)
    {
        Console.WriteLine($"Conta: {conta.Id}, titular: {conta.Titular}, saldo: R$ {conta.Saldo}.");
    }
}

void RealizarTransferencia()
{
    Console.Write("Digite o ID da conta origem: ");
    var contaOrigemId = ObterEConverterValorDigitado<int>();

    Console.Write("\nDigite o ID da conta destino: ");
    var contaDestinoId = ObterEConverterValorDigitado<int>();

    Console.Write("\nDigite o valor da transferência: ");
    var valorTransferencia = ObterEConverterValorDigitado<decimal>();

    LogSeparador();
    Console.WriteLine($"Realizando transferência de R$ {valorTransferencia}.");
    contaBancariaService.Transferir(contaOrigemId, contaDestinoId, valorTransferencia);
    Console.WriteLine($"Transferência de R$ {valorTransferencia} realizada com sucesso.");
    LogSeparador();
}

void EncerrarConta()
{
    Console.Write("Digite o id da conta: ");
    var contaId = ObterEConverterValorDigitado<int>();

    try
    {
        contaBancariaService.Encerrar(contaId);
        Console.WriteLine("Conta encerrada com sucesso.");
    }
    catch (ContaNaoEncerradaException exception)
    {
        Console.WriteLine(exception.Message);
    }
}

void LogSeparador()
{
    Console.WriteLine("\n--------------------------------------------------------------\n");
}

T ObterEConverterValorDigitado<T>()
{
    var valorDigitado = Console.ReadLine();

    if (string.IsNullOrEmpty(valorDigitado))
    {
        Console.WriteLine("O valor digitado não pode ser nulo ou vazio. Digite novamente: ");
        return ObterEConverterValorDigitado<T>();
    }

    try
    {
        return (T)Convert.ChangeType(valorDigitado, typeof(T));
    }
    catch
    {
        Console.WriteLine($"O valor digitado deve ser do tipo {typeof(T)}. Digite novamente: ");
        return ObterEConverterValorDigitado<T>();
    }
}