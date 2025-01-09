using CapaDAL;
using CapaENT;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CrudPracticaExamen.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        // GET: api/<PersonasController>
        [HttpGet]
        public IActionResult Get()
        {
            IActionResult salida;
            List<ClsPersona> listadoCompleto = new List<ClsPersona>();
            try
            {
                listadoCompleto = ListadoPersonasBBDD.ListadoDePersonas();
                if (listadoCompleto.Count() == 0)
                {
                    salida = NoContent();
                }
                else
                {
                    salida = Ok(listadoCompleto);
                }
            }
            catch
            {
                salida = BadRequest();
            }
            return salida;

        }



        // GET api/<PersonasController>/5
        [HttpGet("{id}")]
        public ClsPersona Get(int id)
        {

            IActionResult salida;
            ClsPersona persona = new ClsPersona();
            try
            {
                persona = CrudListado.BuscarPersonaPorId(id);
                if (persona != null)
                {
                    salida = NoContent();
                }
                else
                {
                    salida = Ok(persona);
                }
            }
            catch
            {
                salida = BadRequest();
            }
            return persona;

            
        }

        // POST api/<PersonaAPI>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PersonaAPI>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            IActionResult salida;
            int numFilasAfectadas = 0;
            CrudListado miManejadoraPersona;

            try
            {
                miManejadoraPersona = new CrudListado();
                numFilasAfectadas = CrudListado.BorrarPersona(id);
                if (numFilasAfectadas == 0)
                {
                    salida = NotFound();
                }
                else
                {
                    salida = Ok();
                }
            }
            catch (Exception e)
            {
                salida = BadRequest();
            }

            return salida;
        }

    }
}
