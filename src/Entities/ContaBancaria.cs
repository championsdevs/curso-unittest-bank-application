namespace BankApplication.Entidades;

public class ContaBancaria
{
    public ContaBancaria(
        int id,
        decimal saldo,
        string agencia,
        string conta)
    {
        Id = id;
        Saldo = saldo;
        Agencia = agencia;
        Conta = conta;
    }

    public int Id { get; set; }
    public decimal Saldo { get; set; }
    public string Agencia { get; set; }
    public string Conta { get; set; }

    public void Debitar(decimal valor)
    {
        Saldo -= valor;
    }

    public void Creditar(decimal valor)
    {
        Saldo += valor;
    }
}