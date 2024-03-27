// using BankApplication.Entidades;
using BankApplication.Services;


var contaBancariaService = new ContaBancariaService();
// var valorTransferencia = 50.00m;

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
        case "0":
            return;
        default:
            Console.WriteLine($"O comando digitado ({input}) não é válido");
            continue;
    }
}

void Depositar()
{
    Console.Write("Digite o id da conta: ");
    var idConta = Console.ReadLine();

    Console.Write("Digite o valor a ser depositado: R$ ");
    var valorDeposito = Console.ReadLine();

    var contaBancaria = contaBancariaService.ObterConta(int.Parse(idConta));

    contaBancariaService.Depositar(contaBancaria, decimal.Parse(valorDeposito));

    Console.WriteLine($"Depósito realizado. O saldo atual da conta é R$ {contaBancaria.Saldo}");
}

void LogSeparador()
{
    Console.WriteLine("\n--------------------------------------------------------------\n");
}

void RealizarTransferencia()
{
    Console.Write("Digite o ID da conta origem:");
    var idContaOrigem = Console.ReadLine();

    Console.Write("\nDigite o ID da conta destino:");
    var idContaDestino = Console.ReadLine();

    Console.Write("\nDigite o valor da transferência:");
    var valorTransferencia = decimal.Parse(Console.ReadLine());

    var contaOrigem = contaBancariaService.ObterConta(int.Parse(idContaOrigem));
    var contaDestino = contaBancariaService.ObterConta(int.Parse(idContaDestino));

    Console.WriteLine($"Realizando transferência de R$ {valorTransferencia}");
    Console.WriteLine("-----------------------------");
    Console.WriteLine("Saldo antes da transferência");
    Console.WriteLine($"Saldo conta {contaOrigem.Titular} R$: {contaOrigem.Saldo}");
    Console.WriteLine($"Saldo conta {contaDestino.Titular} R$: {contaDestino.Saldo}");

    contaBancariaService.Transferir(contaOrigem, contaDestino, valorTransferencia);

    Console.WriteLine("-----------------------------");
    Console.WriteLine("Saldo após transferência:");
    Console.WriteLine($"Saldo conta {contaOrigem.Titular} R$: {contaOrigem.Saldo}");
    Console.WriteLine($"Saldo conta {contaDestino.Titular} R$: {contaDestino.Saldo}");
}

void CadastrarConta()
{
    Console.Write("\nDigite o nome do titular da conta");
    var titular = Console.ReadLine();

    var contaBancaria = contaBancariaService.CadastrarConta(titular);

    Console.WriteLine($"Conta cadastrada com sucesso para o titular {titular}. O id da conta é o {contaBancaria.Id}");
}

void ObterContas()
{
    var contasCadastradas = contaBancariaService.ObterContas();

    if (!contasCadastradas.Any())
    {
        Console.WriteLine("Nenhuma conta encontrada");
        return;
    }

    Console.WriteLine("Conta cadastradas:");

    foreach (var conta in contasCadastradas)
    {
        Console.WriteLine($"Conta: {conta.Id}, titular: {conta.Titular}, saldo: R$ {conta.Saldo}");
    }
}

// var contaBancariaPedro = new ContaBancaria(1, 100.25m, "123", "76549");
// var contaBancariaMariana = new ContaBancaria(1, 0.25m, "988", "54331");

