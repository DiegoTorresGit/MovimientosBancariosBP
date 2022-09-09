using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using transaccionalAPI.Models;

namespace transaccionalAPI.Controllers
{
    /// <summary>
    /// Controlador de clientes
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]

    public class ClientesController : ControllerBase
    {
        private readonly Repositories.IClienteRepository tcr;
        public ClientesController(Repositories.IClienteRepository context)
        {
            
            tcr = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Clientes>>> Get()
        {

            return await tcr.GetAll();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Clientes _cliente)
        {
            if (_cliente == null)
            {
                return NotFound("Getting null for student");
            }
            await tcr.Crear(_cliente);
            return Ok("Valor creado");
        }
        [HttpPut]
        public async Task<ActionResult> Put(Clientes _cliente)
        {
            if (_cliente == null)
            {
                return NotFound("No hay datos para actualizar");
            }

            await tcr.Actualizar(_cliente);
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
