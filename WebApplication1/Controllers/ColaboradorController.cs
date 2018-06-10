using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvaCarona.API.Bussiness;
using AvaCarona.API.Domain;
using AvaCarona.API.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/colaborador")]
    public class ColaboradorController : Controller
    {
        private ColaboradorBusiness _business{ get; set; }
        public ColaboradorController(IColaboradorRepositorio colaboradorRepositorio)
        {
            _business = new ColaboradorBusiness(colaboradorRepositorio);
        }

        
        [HttpGet]
        public IEnumerable<Colaborador> Get()
        {
            return _business.List();
        }


        [HttpGet("{id}", Name = "GetColaborador")]
        public IActionResult Get(int id)
        {
            var item = _business.GetById(id);
            if (item == null) return NotFound();
            return new ObjectResult(item);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Colaborador item)
        {
            if (item == null) return BadRequest();
            _business.CadastrarColaborador(item);
            return CreatedAtRoute("GetColaborador", new { id = item.Id }, item);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Colaborador value)
        {
            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            
                var colaborador = _business.GetById(id);
                _business.RemoverColaborador(colaborador);
                return new NoContentResult();
            
        }
    }
}
