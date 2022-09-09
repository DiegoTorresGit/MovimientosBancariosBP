using transaccionalAPI.Context;
using transaccionalAPI.Models;

namespace transaccionalAPI.Repositories.Implements
{
    public class CuentasRepository : GenericRepository<Cuenta>, ICuentasRepository
    {
        public CuentasRepository(ApplicationDBContext dbContext) : base(dbContext) { }



    }
}
