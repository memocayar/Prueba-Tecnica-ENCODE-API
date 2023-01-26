using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;
using API.Services;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActividadesController : ControllerBase
    {
        private readonly IActvidadservice _actvidadservice;

        public ActividadesController(IActvidadservice actvidadservice)
        {
            _actvidadservice = actvidadservice;
        }

        // GET: api/Actividades
        [HttpGet]
        public IActionResult GetActividades()
        {
            return Ok(_actvidadservice.GetAll());
        }

        // GET: api/Actividades/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Actividad>> GetActividad(int id)
        {
            var actividad = await _actvidadservice.GetById(id);

            if (actividad == null)
            {
                return NotFound();
            } 
            return Ok(actividad);
        }

        // DELETE: api/Actividades/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActividad(int id)
        {
            var deleted = _actvidadservice.Delete(id);
            if (await deleted == false)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
