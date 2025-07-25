using Microsoft.AspNetCore.Mvc;
using OriginATM.Dominio;
using OriginATM.Dominio.Enums;
using OriginATM.Repository.Implementacion;
using OriginATM.Repository.Interfaces;
using OriginATM.Web.Models;
using OriginATM.Web.Servicios;

namespace OriginATM.Web.Controllers
{


    public class OperacionesController : Controller
    {
        private readonly IOperacionRepository _operacionRepository;
        private readonly ITarjetaRepository _tarjetaRepository;

        public OperacionesController(IOperacionRepository operacionRepository, ITarjetaRepository tarjetaRepository)
        {
            _operacionRepository = operacionRepository;
            _tarjetaRepository = tarjetaRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Balance()
        {
            return View();
        }

        public IActionResult Retiro()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> VerSaldo()
        {
            string numeroTarjeta = HttpContext.Session.GetString("NumeroTarjeta")!;
            if (numeroTarjeta == null) return RedirectToAction("Index", "Home");

            var tarjeta = await _tarjetaRepository.ObtenerPorNumeroAsync(numeroTarjeta);
            if (tarjeta == null)
            {
                TempData["Error"] = "Tarjeta no encontrada.";
                return RedirectToAction("Error","Auth");
            }

            var operacion = new Operacion
            {
                TarjetaId = tarjeta.Id,
                Fecha = DateTime.Now,
                Tipo = TipoOperacion.ConsultaBalance,
            };

            await _operacionRepository.RegistrarAsync(operacion);

            var model= new BalanceViewModel
            {
                TarjetaId= tarjeta.Id,
                FechaOperacion = operacion.Fecha,
                CodigoOperacion = (int)TipoOperacion.ConsultaBalance,
                NumeroTarjeta = tarjeta.Numero,
                FechaVencimientoTarjeta = tarjeta.FechaVencimiento,
                Balance = tarjeta.Balance
            };

            return View("Balance", model); 
        }
    }
}
