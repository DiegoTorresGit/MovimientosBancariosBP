using Microsoft.EntityFrameworkCore;
using transaccionalAPI.Models;

namespace transaccionalAPI.Context
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<TipoCuenta> TipoCuenta { get; set; }
        public DbSet<Cuenta> Cuenta { get; set; }
        public DbSet<Persona> Persona { get; set; }
        public DbSet<Clientes> Cliente { get; set; }
        public DbSet<Movimientos> Movimiento { get; set; }
        public DbSet<vmEstadoCuenta> EstadoCuentas { get; set; }
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
   : base(options)
        {
        }
    }
}
