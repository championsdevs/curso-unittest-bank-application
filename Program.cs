using BankApplication.Entidades;
using BankApplication.Services;

var contaBancariaService = new ContaBancariaService();
var valorTransferencia = 50.00m;
var contaBancariaPedro = new ContaBancaria(1, 100.25m, "123", "76549");
var contaBancariaMariana = new ContaBancaria(1, 0.25m, "988", "54331");

Console.WriteLine($"Realizando transferência de R$ {valorTransferencia}");
Console.WriteLine("-----------------------------");
Console.WriteLine("Saldo antes da transferência");
Console.WriteLine($"Saldo conta Pedro R$: {contaBancariaPedro.Saldo}");
Console.WriteLine($"Saldo conta Mariana R$: {contaBancariaMariana.Saldo}");

contaBancariaService.RealizarTransferencia(valorTransferencia, contaBancariaPedro, contaBancariaMariana);

Console.WriteLine("-----------------------------");
Console.WriteLine("Saldo após transferência:");
Console.WriteLine($"Saldo conta Pedro R$: {contaBancariaPedro.Saldo}");
Console.WriteLine($"Saldo conta Mariana R$: {contaBancariaMariana.Saldo}");