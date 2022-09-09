using transaccionalAPI.Context;
using transaccionalAPI.Models;

namespace transaccionalAPI.Repositories.Implements
{
    public class MovimientosRepository : GenericRepository<Movimientos>, IMovimientosRepository
    {
        public MovimientosRepository(ApplicationDBContext dbContext) : base(dbContext) { }


    }
}
