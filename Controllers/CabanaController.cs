using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto_Final_Turicentro_Estructura_de_datos.Controllers
{
    public class CabanaController : Controller
    {
        // GET: CabanaController
        public ActionResult Index()
        {
            return View("view_cabanas"); // Asegúrate de que el nombre coincide con la vista en Views/Cabana
        }

        // GET: CabanaController/Details/5
        public ActionResult Details(int id)
        {
            return View(); // Aquí puedes mostrar detalles de la cabaña
        }

        // GET: CabanaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CabanaController/Create
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

        // GET: CabanaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(); // Aquí puedes editar la cabaña
        }

        // POST: CabanaController/Edit/5
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

        // GET: CabanaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(); // Aquí puedes eliminar la cabaña
        }

        // POST: CabanaController/Delete/5
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
