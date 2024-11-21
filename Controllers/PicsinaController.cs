using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto_Final_Turicentro_Estructura_de_datos.Controllers
{
    public class PiscinaController : Controller
    {
        // GET: PiscinaController
        public ActionResult Index()
        {
            return View("view_piscinas"); // Asegúrate de que el nombre coincide con la vista en Views/Piscina
        }

        // GET: PiscinaController/Details/5
        public ActionResult Details(int id)
        {
            return View(); // Aquí puedes mostrar detalles de la piscina
        }

        // GET: PiscinaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PiscinaController/Create
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

        // GET: PiscinaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(); // Aquí puedes editar la piscina
        }

        // POST: PiscinaController/Edit/5
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

        // GET: PiscinaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(); // Aquí puedes eliminar la piscina
        }

        // POST: PiscinaController/Delete/5
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
