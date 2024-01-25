
using Microsoft.EntityFrameworkCore;
using System.Reflection;

public class GestaoProdutoDbContext : DbContext
{
    public GestaoProdutoDbContext(DbContextOptions<GestaoProdutoDbContext> options) : base(options)
    {

    }
    public DbSet<ProdutoEntidade> Produtos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
