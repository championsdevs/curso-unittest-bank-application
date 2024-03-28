using System.Runtime.Serialization;
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

    public ContaBancaria ObterConta(int id)
    {
        return _contaBancariaRepository.ObterConta(id) ?? throw new ContaNaoEncontradaException($"Conta não encontrada para o id {id}");
    }

    public IEnumerable<ContaBancaria> ObterContas()
    {
        return _contaBancariaRepository.ObterContas();
    }

    public void Transferir(int contaOrigemId, int contaDestinoId, decimal valorTransferencia)
    {
        var contaOrigem = ObterConta(contaOrigemId);
        var contaDestino = ObterConta(contaDestinoId);

        contaOrigem.Transferir(contaDestino, valorTransferencia);
        _contaBancariaRepository.PersistirAtualizacoes();
    }

    public decimal Depositar(int contaId, decimal valor)
    {
        var contaBancaria = ObterConta(contaId);
        contaBancaria.Depositar(valor);
        _contaBancariaRepository.PersistirAtualizacoes();

        return contaBancaria.Saldo;
    }

    public void Encerrar(int contaId)
    {
        var contaBancaria = ObterConta(contaId);

        if (contaBancaria!.PossuiSaldo())
        {
            throw new ContaNaoEncerradaException($"É necessário zerar o saldo antes de encerrar a conta. Saldo atual R$ {contaBancaria.Saldo}.");
        }

        _contaBancariaRepository.RemoverConta(contaBancaria);
    }

    public decimal Sacar(int contaId, decimal valorSaque)
    {
        var contaBancaria = ObterConta(contaId);

        if (!contaBancaria.PodeSacar(valorSaque))
        {
            throw new SaldoInsuficienteException();
        }

        contaBancaria.Sacar(valorSaque);

        _contaBancariaRepository.PersistirAtualizacoes();

        return contaBancaria.Saldo;
    }
}

