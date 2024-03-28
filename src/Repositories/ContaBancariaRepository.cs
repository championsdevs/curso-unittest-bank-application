using BankApplication.Entidades;

namespace BankApplication.Repositories;

public class ContaBancariaRepository(BankApplicationDbContext dbContext)
{
    private readonly BankApplicationDbContext _dbContext = dbContext;

    public void PersistirConta(ContaBancaria contaBancaria)
    {
        _dbContext.Add(contaBancaria);
        PersistirAtualizacoes();
    }

    public ContaBancaria? ObterConta(int id)
    {
        return _dbContext.ContasBancarias.FirstOrDefault(c => c.Id == id);
    }

    public IEnumerable<ContaBancaria> ObterContas()
    {
        return _dbContext.ContasBancarias.AsEnumerable();
    }

    public void PersistirAtualizacoes()
    {
        _dbContext.SaveChanges();
    }

    public void RemoverConta(ContaBancaria contaBancaria)
    {
        _dbContext.Remove(contaBancaria);
        PersistirAtualizacoes();
    }
}