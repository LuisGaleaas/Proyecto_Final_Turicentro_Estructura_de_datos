using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto_Final_Turicentro_Estructura_de_datos.Controllers
{
    public class ActividadController : Controller
    {
        // GET: ActividadController
        public ActionResult Index()
        {
            return View("view_actividades"); // Asegúrate de que el nombre coincide con la vista en Views/Actividad
        }

        // GET: ActividadController/Details/5
        public ActionResult Details(int id)
        {
            return View(); // Aquí puedes mostrar detalles de la actividad
        }

        // GET: ActividadController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ActividadController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: ActividadController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(); // Aquí puedes editar la actividad
        }

        // POST: ActividadController/Edit/5
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

        // GET: ActividadController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(); // Aquí puedes eliminar la actividad
        }

        // POST: ActividadController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
    }
}
