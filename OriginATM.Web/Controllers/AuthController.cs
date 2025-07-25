using Microsoft.AspNetCore.Mvc;
using OriginATM.Infraestructura;
using OriginATM.Web.Models;

namespace OriginATM.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AuthController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Home()
        {
            return View();
        }
        public IActionResult Error()
        {
            string mensaje = TempData["MensajeError"].ToString();

            return View("_Error", new ErrorViewModel { Mensaje = mensaje });
        }

        [HttpPost]
        public async Task<IActionResult> VerificarTarjeta(string numeroPlano)
        {
            const int cantCaracteresTarjeta = 16;
            if (string.IsNullOrWhiteSpace(numeroPlano) || numeroPlano.Length != cantCaracteresTarjeta)
            {
                TempData["MensajeError"] = "Debe ingresar un número de tarjeta válido de 16 dígitos.";
                return RedirectToAction("Error");
            }

            var tarjetaValida = _context.Tarjetas.Any(t => t.Numero == numeroPlano && t.EstaBloqueada==false);

            return RedirectToAction("IngresarPin", new { numero = numeroPlano });
        }

        public IActionResult IngresarPin()
        {
            return View();
        }
    }
}
