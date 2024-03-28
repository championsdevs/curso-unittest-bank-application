namespace BankApplication.Entidades;

public class ContaBancaria
{
    public ContaBancaria(string titular)
    {
        var random = new Random();

        Titular = titular;
        Saldo = 0;
        Agencia = random.Next(1, 10).ToString();
        Conta = random.Next(1, int.MaxValue).ToString();
    }

    public int Id { get; init; }
    public string Titular { get; init; }
    public decimal Saldo { get; private set; }
    public string Agencia { get; init; }
    public string Conta { get; init; }

    public void Sacar(decimal valor)
    {
        if (!PossuiSaldoMaiorOuIgual(valor))
            throw new SaldoInsuficienteException();

        Saldo -= valor;
    }

    public void Depositar(decimal valor)
    {
        Saldo += valor;
    }

    public void Transferir(ContaBancaria contaDestino, decimal valorTransferencia)
    {
        Sacar(valorTransferencia);
        contaDestino.Depositar(valorTransferencia);
    }

    public bool PossuiSaldo()
    {
        return Saldo > 0;
    }

    private bool PossuiSaldoMaiorOuIgual(decimal valorSaque)
    {
        return Saldo >= valorSaque;
    }
}