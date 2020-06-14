using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MBBackend.IServices;
using MBBackend.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MBBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private IEmpleadoService _oEmpleadoService;

        public EmpleadosController(IEmpleadoService oEmpleadoService)
        {
            _oEmpleadoService = oEmpleadoService;
        }

        // GET: api/<EmpleadosController>
        [HttpGet]
        public IEnumerable<Empleado> Get()
        {
            return _oEmpleadoService.Gets();
        }

        // GET api/<EmpleadosController>/5
        [HttpGet("{id}", Name = "Get")]
        public Empleado Get(int id)
        {
            return _oEmpleadoService.Get(id);                     
            
            
        }

        // POST api/<EmpleadosController>
        [HttpPost]
        public void Post([FromBody] Empleado oEmpleado)
        {
            if (ModelState.IsValid) _oEmpleadoService.Add(oEmpleado);
        }

        // PUT api/<EmpleadosController>/5
        [HttpPut]
        public void Put([FromBody] Empleado oEmpleado)
        {
            if (ModelState.IsValid) _oEmpleadoService.Update(oEmpleado);
        }

        // DELETE api/<EmpleadosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (id != 0) _oEmpleadoService.Delete(id);
        }
    }
}
