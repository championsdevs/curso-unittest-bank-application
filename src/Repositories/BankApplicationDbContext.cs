using BankApplication.Entidades;
using Microsoft.EntityFrameworkCore;

namespace BankApplication.Repositories;

public class BankApplicationDbContext : DbContext
{
    public DbSet<ContaBancaria> ContasBancarias { get; set; }

    public string DbPath { get; }

    public BankApplicationDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "bank-account.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}