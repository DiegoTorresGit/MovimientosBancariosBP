using Microsoft.AspNetCore.Mvc;
using System;
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
        public async Task<ActionResult<IEnumerable<vmEstadoCuenta>>> Get(DateTime FI, DateTime FF, string Cuenta)
        {
            vmEstadoCuenta s = new vmEstadoCuenta();
            //s.numeroCuenta = Cuenta;
            //tcr.EstadoCuenta(FF,FF,Cuenta);
            return tcr.EstadoCuenta(FF, FF, Cuenta);
        }
    }
}
