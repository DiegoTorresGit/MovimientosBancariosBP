using System.Collections.Generic;
using System.Threading.Tasks;
using transaccionalAPI.Models;

namespace transaccionalAPI.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAll();

        Task<TEntity> GetById(int id);

        //bool Crear(TEntity entity);
        Task<TEntity> Crear(TEntity entity);

        Task<TEntity> Actualizar(TEntity entity);

        Task<TEntity> Editar(TEntity entity);

        Task  Eliminar(int id);

        Task<string> GuardarMovimiento(Movimientos entity);

        List<vmEstadoCuenta> EstadoCuenta(vmEstadoCuenta entity);
    }
}
