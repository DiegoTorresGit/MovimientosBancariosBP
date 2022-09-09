using transaccionalAPI.Context;
using transaccionalAPI.Models;

namespace transaccionalAPI.Repositories.Implements
{
    public class EstadoCuentaRepository : GenericRepository<vmEstadoCuenta>, IEstadoCuenta
    {
        public EstadoCuentaRepository(ApplicationDBContext dbContext) : base(dbContext) { }



    }
}
