using BankApplication.Entidades;

namespace BankApplication.Services;

public class ContaBancariaService
{
    public void RealizarTransferencia(decimal valorTransferencia, ContaBancaria contaOrigem, ContaBancaria contaDestino)
    {
        contaOrigem.Debitar(valorTransferencia);
        contaDestino.Creditar(valorTransferencia);
    }
}