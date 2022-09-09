using Microsoft.AspNetCore.Mvc;
using transaccionalAPI.Context;
using transaccionalAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net;
using System;
using System.Net.Http;
using Refit;

namespace transaccionalAPI.Controllers
{

    public class TipoCuentasController : ControllerBase
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}
        private readonly Repositories.ITipoCuentaRepository tcr;
        //private readonly ApplicationDBContext _context;

        //public TipoCuentasController(ApplicationDBContext context)
        //{
        //    _context = context;

        //}

        public TipoCuentasController(Repositories.ITipoCuentaRepository context)
        {
            tcr = context;

        }

        //private readonly TRepository repository;
        //public MyMDBController(Repositories.ITipoCuentaRepository repository)
        //{
        //    this.repository = repository;
        //}

        // GET: api/Productos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoCuenta>>> Get()
        {

            return await tcr.GetAll();
        }

        [HttpPost]
        public async Task<ActionResult> Post(TipoCuenta tipoCuenta)
        {

            if (tipoCuenta == null)
            {
                return NotFound("Getting null for student");
            }

            await tcr.Crear(tipoCuenta);
            return Ok("Valor creado");

            //try
            //tipoCuenta.codigo_tc = 0;
            //tcr.Crear(tipoCuenta);
            //return Ok("Valor creado");
            //}
            //catch (Exception ex)
            //{
            //    return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            //}
            //return CustomResult("Post save failed.", HttpStatusCode.BadRequest);
        }
        [HttpPut]
        public async Task<ActionResult> Put(TipoCuenta tipoCuenta)
        {
            if (tipoCuenta == null)
            {
                return NotFound("Getting null for student");
            }

            await tcr.Actualizar(tipoCuenta);
            return Ok("Valor actualizado");
        }


    }
}
