using AvaCarona.API.Bussiness;
using AvaCarona.API.Domain;
using AvaCarona.API.Repositorios;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvaCaronaWebAPI.Controllers
{
    [Route("api/carona")]
    public class CaronaController : Controller
    {
        
        
            private CaronaBusiness _business { get; set; }
            public CaronaController(ICaronaRepository caronaRepositorio)
            {
                _business = new CaronaBusiness(caronaRepositorio);
            }


            [HttpGet]
            public IEnumerable<Carona> Get()
            {
                return _business.List();
            }


            [HttpGet("{id}", Name = "GetCarona")]
            public IActionResult Get(int id)
            {
                var item = _business.GetById(id);
                if (item == null)
                {
                    return NotFound();
                }
                return new ObjectResult(item);
            }

            // POST api/values
            [HttpPost]
            public IActionResult Post([FromBody]Carona item)
            {
                if (item == null) return BadRequest();
                _business.CadastrarCarona(item);
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

                var carona = _business.GetById(id);
                _business.RemoverCarona(carona);
                return new NoContentResult();

            }
        }
}
