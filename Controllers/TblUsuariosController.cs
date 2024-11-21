using Microsoft.AspNetCore.Mvc;
using Proyecto_Final_Turicentro_Estructura_de_datos.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace Proyecto_Final_Turicentro_Estructura_de_datos.Controllers
{
    public class TblUsuariosController : Controller
    {
        private readonly DbTuricentroContext _context;

        public TblUsuariosController(DbTuricentroContext context)
        {
            _context = context;
        }

        // GET: TblUsuarios/Login
        public IActionResult Login()
        {
            return View(); // Muestra la vista Login.cshtml
        }

        // GET: TblUsuarios/RegistroCliente
        public IActionResult RegistroCliente()
        {
            return View(); // Muestra la vista RegistroCliente.cshtml
        }
        public IActionResult ViewCliente()
        {
            return View();
        }
        public IActionResult view_quehacer()
        {
            return View();
        }

        // POST: TblUsuarios/RegistroCliente
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegistroCliente(TblUsuario usuario)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Verifica si ya existe un usuario con el mismo correo
                    var usuarioExistente = await _context.TblUsuarios.FirstOrDefaultAsync(u => u.Correo == usuario.Correo);
                    if (usuarioExistente != null)
                    {
                        ViewBag.Error = "El correo ya está registrado.";
                        return View(usuario);
                    }

                    // Asigna el rol predeterminado como Cliente
                    usuario.Rol = "Cliente";

                    // Agrega el usuario a la base de datos
                    _context.Add(usuario);
                    await _context.SaveChangesAsync();

                    // Redirige al Login después del registro exitoso
                    TempData["Success"] = "Registro exitoso. Por favor, inicie sesión.";
                    return RedirectToAction("Login");
                }
                catch
                {
                    ViewBag.Error = "Ocurrió un error al registrar el cliente. Por favor, intente nuevamente.";
                }
            }

            // Si algo falla, muestra la vista de registro con los datos actuales
            return View(usuario);
        }
        

        // POST: TblUsuarios/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(TblUsuario usuario)
        {
            if (string.IsNullOrWhiteSpace(usuario.Correo) || string.IsNullOrWhiteSpace(usuario.Contraseña))
            {
                ViewBag.Error = "Correo y contraseña son requeridos.";
                return View();
            }

            // Verifica las credenciales del usuario en la base de datos
            var usuarioEncontrado = await _context.TblUsuarios
                .FirstOrDefaultAsync(u => u.Correo == usuario.Correo && u.Contraseña == usuario.Contraseña);

            if (usuarioEncontrado != null)
            {
                // Establece la sesión
                HttpContext.Session.SetInt32("UsuarioID", usuarioEncontrado.UsuarioId);
                HttpContext.Session.SetString("Rol", usuarioEncontrado.Rol);

                // Redirige según el rol
                if (usuarioEncontrado.Rol == "Administrador")
                {
                    return RedirectToAction("Dashboard", "Admin");
                }
                if (usuarioEncontrado.Rol == "Cliente")
                {
                    return RedirectToAction("ViewCliente", "TblUsuarios");
                }

            }
            else
            {
                ViewBag.Error = "Correo o contraseña incorrectos.";
            }

            return View();
        }

        private int ObtenerUsuarioIdDeSesion()
        {
            // Obtiene el UsuarioId de la sesión
            var usuarioId = HttpContext.Session.GetInt32("UsuarioID");

            if (!usuarioId.HasValue)
            {
                throw new UnauthorizedAccessException("Usuario no autenticado.");
            }

            return usuarioId.Value;
        }
        // Acción para cerrar sesión
        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); // Limpia la sesión
            return RedirectToAction("Login");
        }

        private bool TblUsuarioExists(int id)
        {
            return _context.TblUsuarios.Any(e => e.UsuarioId == id);
        }
    }
}
