using System.Threading.Tasks;
using transaccionalAPI.Context;
using transaccionalAPI.Models;

namespace transaccionalAPI.Repositories.Implements
{
    public class TipoCuentaRepository : GenericRepository<TipoCuenta>, ITipoCuentaRepository
    {
        public TipoCuentaRepository(ApplicationDBContext dbContext) : base(dbContext) { }



    }
}
