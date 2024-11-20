using Gerenciador_Manutencao.Model;
using Microsoft.EntityFrameworkCore;

namespace Gerenciador_Manutencao.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Item> Itens { get; set; }
    public DbSet<Manutencao> Manutencoes { get; set; }
    public DbSet<Modelo> Modelos { get; set; }
    public DbSet<OrdemServico> OrdemServicos { get; set; }
    public DbSet<Equipamento> Equipamentos { get; set; }
}
