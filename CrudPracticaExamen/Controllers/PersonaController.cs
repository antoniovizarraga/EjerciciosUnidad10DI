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
            ClsPersona persona = ListadoPersonasBBDD.personaSeleccionada(id);

           

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
                ListadoPersonasBBDD.CreaPersonaDAL(persona);

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
            

            var persona = ListadoPersonasBBDD.personaSeleccionada(id);
            return View(persona);
        }

        // POST: PersonaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClsPersona persona)
        {
            try
            {
                //ClsPersona personaEditada = new ClsPersona(id, Nombre, Apellidos, Telefono, Direccion, Foto, FechaNacimiento, IDDepartamento);

                ListadoPersonasBBDD.EditaPersonaDAL(persona);

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

            ClsPersona personaABorrar = ListadoPersonasBBDD.personaSeleccionada(id);

            var persona = ListadoPersonasBBDD.BorraPersonaDAL(id);
            return View(personaABorrar);
        }

        // POST: PersonaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                ListadoPersonasBBDD.BorraPersonaDAL(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
