using MicroservicioPrueba.Entities;
using Microsoft.EntityFrameworkCore;

namespace MicroservicioPrueba.Interfaces
{
    public interface IAppDBContext
    {
        DbSet<Cliente> Cliente { get; set; }
        DbSet<Cuenta> Cuenta { get; set; }
        DbSet<Movimientos> Movimientos { get; set; }
        DbSet<TipoCuenta> TipoCuenta { get; set; }
        DbSet<TipoMovimiento> TipoMovimiento { get; set; }
        DbSet<Parametros> Parametros { get; set; }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}