using BankApplication.Entidades;
using BankApplication.Repositories;

namespace BankApplication.Services;

public class ContaBancariaService
{
    private readonly ContaBancariaRepository _contaBancariaRepository;

    public ContaBancariaService()
    {
        _contaBancariaRepository = new ContaBancariaRepository(new BankApplicationDbContext());
    }

    public ContaBancaria CadastrarConta(string titular)
    {
        var contaBancaria = new ContaBancaria(titular);
        _contaBancariaRepository.PersistirConta(contaBancaria);
        return contaBancaria;
    }

    public ContaBancaria? ObterConta(int id)
    {
        return _contaBancariaRepository.ObterConta(id);
    }

    public IEnumerable<ContaBancaria> ObterContas()
    {
        return _contaBancariaRepository.ObterContas();
    }

    public void Transferir(ContaBancaria contaOrigem, ContaBancaria contaDestino, decimal valorTransferencia)
    {
        contaOrigem.Transferir(contaDestino, valorTransferencia);
        _contaBancariaRepository.PersistirAtualizacoes();
    }

    public void Depositar(ContaBancaria contaBancaria, decimal valor)
    {
        contaBancaria.Depositar(valor);
        _contaBancariaRepository.PersistirAtualizacoes();
    }
}