﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using transaccionalAPI.Models;

namespace transaccionalAPI.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class PersonasController : ControllerBase
    {
        private readonly Repositories.IPersonaRepository tcr;
        public PersonasController(Repositories.IPersonaRepository context)
        {
            tcr = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Persona>>> Get()
        {

            return await tcr.GetAll();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Persona _persona)
        {
            if (_persona == null)
            {
                return NotFound("Getting null for student");
            }
            await tcr.Crear(_persona);
            return Ok("Valor creado");
        }
        [HttpPut]
        public async Task<ActionResult> Put(Persona _persona)
        {
            if (_persona == null)
            {
                return NotFound("Getting null for student");
            }

            await tcr.Actualizar(_persona);
            return Ok("Valor actualizado");
        }

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    try
        //    {
        //        if (id == 0)
        //        {
        //            return NotFound("Debe especificar un id cuenta");
        //        }
        //        await tcr.Eliminar(id);
        //        return Ok("Valor eliminado");
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok("Se produjo una excepcion. Mensaje: " + ex.Message);
        //    }
        //}
    }
}
