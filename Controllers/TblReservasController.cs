using System.Security.Claims; // Para trabajar con Claims
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_Final_Turicentro_Estructura_de_datos.Models;

namespace Proyecto_Final_Turicentro_Estructura_de_datos.Controllers
{
    public class TblReservasController : Controller
    {
        private readonly DbTuricentroContext _context;

        public TblReservasController(DbTuricentroContext context)
        {
            _context = context;
        }

        // Acción para mostrar la vista de reservas
        // Acción para mostrar el formulario de creación de reserva
        public IActionResult Create()
        {
            return View();
        }

        // Acción para procesar el formulario y guardar la reserva
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TblReserva reserva)
        {
            if (ModelState.IsValid)
            {
                // Guardar la reserva en la base de datos
                _context.TblReservas.Add(reserva);
                _context.SaveChanges();

                // Mostrar mensaje de éxito
                ViewData["SuccessMessage"] = "Reserva creada exitosamente.";

                // Mostrar la reserva creada
                ViewData["ReservaCreada"] = reserva;

                return View(); // Retornar la vista con la reserva creada
            }

            // Si el modelo no es válido, volver al formulario con los errores
            return View(reserva);
        }




        // Acción para ver todas las reservas
        public async Task<IActionResult> Index()
        {
            var dbTuricentroContext = _context.TblReservas.Include(t => t.Area).Include(t => t.Usuario);
            return View(await dbTuricentroContext.ToListAsync());
        }

        // Acción para ver detalles de una reserva
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var tblReserva = await _context.TblReservas
                .Include(t => t.Area)
                .Include(t => t.Usuario)
                .FirstOrDefaultAsync(m => m.ReservaId == id);

            if (tblReserva == null) return NotFound();

            return View(tblReserva);
        }

        // Acción para eliminar una reserva
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var tblReserva = await _context.TblReservas
                .Include(t => t.Area)
                .Include(t => t.Usuario)
                .FirstOrDefaultAsync(m => m.ReservaId == id);

            if (tblReserva == null) return NotFound();

            return View(tblReserva);
        }

        // Confirmar la eliminación de una reserva
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblReserva = await _context.TblReservas.FindAsync(id);
            if (tblReserva != null)
            {
                _context.TblReservas.Remove(tblReserva);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblReservaExists(int id)
        {
            return _context.TblReservas.Any(e => e.ReservaId == id);
        }
    }
}