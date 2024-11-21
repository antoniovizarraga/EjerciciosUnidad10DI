using CapaDAL;
using CapaENT;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudPracticaExamen.Controllers
{
    public class PersonaController : Controller
    {
        

        // GET: PersonaController
        public ActionResult Index()
        {
            var listado = ListadoPersonasBBDD.ListadoDePersonas();
            return View(listado);
        }

        // GET: PersonaController/Details/5
        public ActionResult Details(int id)
        {
            var persona = CrudListado.BuscarPersonaPorId(id);

           

            return View(persona);
        }

        // GET: PersonaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClsPersona persona)
        {
            try
            {
                //ListadoPersonas.AddPersona(persona.Nombre, persona.Apellidos, persona.Telefono, persona.Direccion, persona.Foto, persona.FechaNacimiento, persona.IDDepartamento);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonaController/Edit/5
        public ActionResult Edit(int id)
        {
            var persona = CrudListado.BuscarPersonaPorId(id);
            return View(persona);
        }

        // POST: PersonaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonaController/Delete/5
        public ActionResult Delete(int id)
        {
            
            
            return View();
        }

        // POST: PersonaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                CrudListado.BorrarPersona(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
