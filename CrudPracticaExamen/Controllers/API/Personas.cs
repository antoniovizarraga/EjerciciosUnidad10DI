using CapaDAL;
using CapaENT;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CrudPracticaExamen.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class Personas : ControllerBase
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
        public IActionResult Post([FromBody] ClsPersona persona)
        {
            IActionResult salida;

            bool result;

            result = ListadoPersonasBBDD.CreaPersonaDAL(persona);

            if(result)
            {
                salida = Ok(persona);
            } else
            {
                salida = NoContent();
            }

            return salida;
        }

        // PUT api/<PersonaController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] ClsPersona persona)
        {
            IActionResult salida;
            if (persona != null)
            {

                try
                {
                    ListadoPersonasBBDD.EditaPersonaDAL(persona);
                    salida = Ok(persona);
                }
                catch
                {
                    salida = BadRequest();
                }
            }
            else
            {
                salida = NoContent();
            }

            return salida;
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            IActionResult salida;
            int numFilasAfectadas = 0;
            CrudListado miManejadoraPersona;

            try
            {
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
