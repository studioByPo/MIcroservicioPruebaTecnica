using MicroservicioPrueba.Entities;
using MicroservicioPrueba.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace MicroservicioPrueba.Context;

public class AppDBContext : DbContext, IAppDBContext
{
    public DbSet<Cliente> Cliente { get; set; }

    public DbSet<Cuenta> Cuenta { get; set; }

    public DbSet<Movimientos> Movimientos { get; set; }

    public DbSet<TipoCuenta> TipoCuenta { get; set; }

    public DbSet<TipoMovimiento> TipoMovimiento { get; set; }

    public DbSet<Parametros> Parametros { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            @"Server=DESKTOP-4TGDDIC\SQLEXPRESS;Database=API;Trusted_Connection=True;MultipleActiveResultSets=true;");
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
    {
        return base.SaveChangesAsync(acceptAllChangesOnSuccess: true, cancellationToken);
    }
}
