using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using transaccionalAPI.Context;
using transaccionalAPI.Models;

namespace transaccionalAPI.Repositories.Implements
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDBContext Transaccionales;

        public GenericRepository(ApplicationDBContext Transaccionales)
        {
            this.Transaccionales = Transaccionales;
        }
        public int Count()
        {
            return Transaccionales.Set<TEntity>().ToList().Count();
        }
        public async Task Eliminar(int id)
        {
            try
            {
                var entity = await GetById(id);
                if (entity == null)
                    throw new Exception("The entity is null");

                 Transaccionales.Set<TEntity>().Remove(entity);
                await Transaccionales.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public async Task<List<TEntity>> GetAll()
        {
            return await Transaccionales.Set<TEntity>().ToListAsync();
        }
        public async Task<TEntity> GetById(int id)
        {
            try
            {
                return await Transaccionales.Set<TEntity>().FindAsync(id);
            }
            catch (Exception e)
            {
                return null;
                
            }         
        }
        public async Task<TEntity> Crear(TEntity entity)
        {
            try
            {
                Transaccionales.Set<TEntity>().Add(entity);
                await Transaccionales.SaveChangesAsync();
                return entity;
            }
            catch (Exception e)
            {
                string a = e.Message;
                return null;
            }
    
        }
        public async Task<TEntity> Actualizar(TEntity entity)
        {
            Transaccionales.Set<TEntity>().Update(entity);
            await Transaccionales.SaveChangesAsync();
            return entity;
        }
        public async Task<TEntity> Editar(TEntity entity)
        {
            Transaccionales.Set<TEntity>().Update(entity);
            await Transaccionales.SaveChangesAsync();
            return entity;
        }
        public async Task<string> GuardarMovimiento(transaccionalAPI.Models.Movimientos _movimiento)
        {
            try
            {
                decimal saldo = 0;
                _movimiento.codigo_mov = 0;
                int idCuneta = _movimiento.codigo_cue;
                int ce = Transaccionales.Cuenta.Where(a => a.codigo_cue == idCuneta).Count();
                if (ce==0)
                {
                    return "La cuenta no existe";
                }

                int me= Transaccionales.Movimiento.Where(a => a.codigo_cue == idCuneta).Count();
                if (me==0)
                {
                    saldo= Transaccionales.Cuenta.Where(a => a.codigo_cue == idCuneta).FirstOrDefault().saldo_inicial_cue;
                }
                else
                {
                    saldo = Transaccionales.Movimiento.Where(a => a.codigo_cue == idCuneta && a.codigo_cue==_movimiento.codigo_tm).OrderByDescending(z => z.fecha_mov).FirstOrDefault().saldo_mov;
                }
               
                decimal movimiento = _movimiento.valor_mov;
                //decimal saldo = Transaccionales.Movimiento.Where(a =>a.codigo_cue == idCuneta).OrderByDescending(z=> z.fecha_mov).FirstOrDefault().saldo_mov;
                DateTime fechaActual = DateTime.Now.AddDays(-10);
                DateTime fechaSiguiente = DateTime.Now.AddDays(1);
                decimal reitoDiario = (from mov in Transaccionales.Movimiento where mov.fecha_mov > fechaActual && mov.fecha_mov < fechaSiguiente && mov.codigo_tm==1 select mov.valor_mov).Sum();

                if ((reitoDiario+ movimiento)>1000 && _movimiento.codigo_tm==1)
                {
                    return "Cupo diario excedido";
                }
                    if (_movimiento.codigo_tm == 1)
                    {
                        if (saldo>=movimiento)
                        {
                            saldo = saldo - _movimiento.valor_mov;
                        movimiento = movimiento * -1;
                        }
                        else
                        {
                            return "saldo no disponible";
                        }                     
                    }
                    else
                    {
                        saldo = saldo + _movimiento.valor_mov;
                    }
                    _movimiento.saldo_mov = saldo;
                    Transaccionales.Add(_movimiento);
                    await Transaccionales.SaveChangesAsync();
                    return "Movimiento almacenado";
            }
            catch (Exception e)
            {
                string a = e.Message;
                return null;
            }
        }
        public List<vmEstadoCuenta> EstadoCuenta(DateTime FI, DateTime FF, string Cuenta)
        {
            FI = FI.AddDays(-1);
            FF = FF.AddDays(1);
            try
            {
                var Estado = (from clie in Transaccionales.Cliente
                              join per in Transaccionales.Persona
                              on clie.codigo_per equals per.codigo_per
                              join cue in Transaccionales.Cuenta on clie.codigo_cli equals cue.codigo_cli
                              join tc in Transaccionales.TipoCuenta on cue.codigo_tc equals tc.codigo_tc
                              join mo in Transaccionales.Movimiento on cue.codigo_cue equals mo.codigo_cue
                              where cue.numero_cue == Cuenta & mo.fecha_mov>FI & mo.fecha_mov<FF
                              select new
                              {
                                  mo.fecha_mov,
                                  per.nombre_per,
                                  cue.numero_cue,
                                  tc.cuenta_tc,
                                  cue.saldo_inicial_cue,
                                  clie.estado_cli,
                                  mo.valor_mov,
                                  mo.saldo_mov
                              }).ToList();
                List<vmEstadoCuenta> vmEC = new List<vmEstadoCuenta>();
                foreach (var item in Estado)
                {
                    vmEstadoCuenta vm = new vmEstadoCuenta();
                    
                    vm.fechaInicio = item.fecha_mov.ToString();
                    vm.Cliente = item.nombre_per;
                    vm.numeroCuenta = item.numero_cue;
                    vm.tipo = item.cuenta_tc;
                    vm.saldoInicial = item.saldo_inicial_cue;
                    vm.estado = (item.estado_cli==true ? "True": "False");
                    vm.saldoDisponible = item.saldo_mov;
                    vm.movimiento = item.valor_mov;
                    vmEC.Add(vm);
                }
                return vmEC.ToList();
            }
            catch (Exception e)
            {
                return null;

            }
        }
    }
}

