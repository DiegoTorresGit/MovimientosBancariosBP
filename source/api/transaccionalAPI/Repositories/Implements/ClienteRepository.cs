using transaccionalAPI.Context;
using transaccionalAPI.Models;

namespace transaccionalAPI.Repositories.Implements
{
    public class ClienteRepository : GenericRepository<Clientes>, IClienteRepository
    {
        public ClienteRepository(ApplicationDBContext dbContext) : base(dbContext) { }
    }
}
