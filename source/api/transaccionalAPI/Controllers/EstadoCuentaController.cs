using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using transaccionalAPI.Models;

namespace transaccionalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoCuentaController : ControllerBase
    {
        private readonly Repositories.IEstadoCuenta tcr;
        public EstadoCuentaController(Repositories.IEstadoCuenta context)
        {
            tcr = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<vmEstadoCuenta>>> Get()
        {
            vmEstadoCuenta s = new vmEstadoCuenta();
            s.numeroCuenta = "478758";
            tcr.EstadoCuenta(s);
            return tcr.EstadoCuenta(s);
        }


        //[HttpGet]
        //public async Task<ActionResult> Get(vmEstadoCuenta _movimientos)
        //{
        //     tcr.EstadoCuenta(_movimientos);
        //    return Ok("Consulta exitosa");
        //}
    }
}
