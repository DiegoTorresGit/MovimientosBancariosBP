using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using transaccionalAPI.Models;

namespace transaccionalAPI.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class MovimientosController : ControllerBase
        {
            private readonly Repositories.IMovimientosRepository tcr;
            public MovimientosController(Repositories.IMovimientosRepository context)
            {
                tcr = context;
            }
            [HttpGet]
            public async Task<ActionResult<IEnumerable<Movimientos>>> Get()
            {

                return await tcr.GetAll();
            }

            [HttpPost]
            public async Task<ActionResult> Post(Movimientos _movimientos)
            {
                if (_movimientos == null)
                {
                    return NotFound("Los datos no pueden ser nulos");
                }
                string m= await tcr.GuardarMovimiento(_movimientos);
                return Ok(m);
            }
            [HttpPut]
            public async Task<ActionResult> Put(Movimientos _movimientos)
            {
                if (_movimientos == null)
                {
                    return NotFound("No hay datos para actualizar");
                }

                await tcr.Actualizar(_movimientos);
                return Ok("Valor actualizado");
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(int id)
            {
                try
                {
                    if (id == 0)
                    {
                        return NotFound("Debe especificar un id cuenta");
                    }
                    await tcr.Eliminar(id);
                    return Ok("Valor eliminado");
                }
                catch (Exception ex)
                {
                    return Ok("Se produjo una excepcion. Mensaje: " + ex.Message);
                }
            }
        }
    }

