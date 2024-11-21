using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto_Final_Turicentro_Estructura_de_datos.Controllers
{
    public class PicnicController : Controller
    {
        // GET: PicnicController
        public ActionResult Index()
        {
            return View("view_picnic"); // Asegúrate de que el nombre coincide con la vista en Views/Picnic
        }

        // GET: PicnicController/Details/5
        public ActionResult Details(int id)
        {
            return View(); // Aquí puedes mostrar detalles del picnic
        }

        // GET: PicnicController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PicnicController/Create
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

        // GET: PicnicController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(); // Aquí puedes editar el picnic
        }

        // POST: PicnicController/Edit/5
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

        // GET: PicnicController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(); // Aquí puedes eliminar el picnic
        }

        // POST: PicnicController/Delete/5
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
