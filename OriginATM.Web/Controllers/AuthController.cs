using Microsoft.AspNetCore.Mvc;
using OriginATM.Dominio;
using OriginATM.Infraestructura;
using OriginATM.Repository.Implementacion;
using OriginATM.Repository.Interfaces;
using OriginATM.Web.Models;
using System.Net.NetworkInformation;

namespace OriginATM.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly ITarjetaRepository _tarjetaRepository;

        public AuthController(ITarjetaRepository tarjetaRepository)
        {
            _tarjetaRepository = tarjetaRepository;
        }

        [HttpGet]
        public IActionResult IngresarTarjeta()
        {
            return View();
        }
        public IActionResult Error()
        {
            string mensaje = TempData["Error"]!.ToString()!;

            return View("_Error", new ErrorViewModel { Mensaje = mensaje });
        }

        [HttpPost]
        public async Task<IActionResult> VerificarTarjeta(string numeroTarjeta)
        {
            var tarjeta = await _tarjetaRepository.ObtenerPorNumeroAsync(numeroTarjeta);

            if (tarjeta == null)
            {
                TempData["Error"] = "Tarjeta inexistente.";
                return RedirectToAction("Error");
            }
            if (tarjeta.EstaBloqueada)
            {
                TempData["Error"] = "Tarjeta bloqueada.";
                return RedirectToAction("Error");
            }
            HttpContext.Session.SetString("NumeroTarjeta", tarjeta.Numero);

            return RedirectToAction("IngresarPIN");
        }

        [HttpGet]
        public IActionResult IngresarPin()
        {
            var numeroTarjeta = HttpContext.Session.GetString("NumeroTarjeta");

            if (string.IsNullOrEmpty(numeroTarjeta))
            {
                TempData["Error"] = "Sesión expirada. Vuelva a ingresar la tarjeta.";
                return RedirectToAction("Error");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> VerificarPIN(string inputPIN)
        {
            const int CANTMAXINTENTOSFALLIDOS = 3;
            string numeroTarjeta = HttpContext.Session.GetString("NumeroTarjeta")!;

            if (string.IsNullOrEmpty(numeroTarjeta))
            {
                TempData["Error"] = "Sesión expirada. Vuelva a ingresar la tarjeta.";
                return RedirectToAction("Error");
            }

            var tarjeta = await _tarjetaRepository.ObtenerPorNumeroAsync(numeroTarjeta);

            if (tarjeta == null)
            {
                TempData["Error"] = "Tarjeta no encontrada.";
                return RedirectToAction("Error");
            }

            if (tarjeta.EstaBloqueada)
            {
                TempData["Error"] = "La tarjeta se encuentra bloqueada.";
                return RedirectToAction("IngresarTarjeta");
            }

            if (!tarjeta.Pin.Equals(inputPIN))
            {
                tarjeta.IntentosFallidos++;
                if (tarjeta.IntentosFallidos > CANTMAXINTENTOSFALLIDOS)
                {
                    tarjeta.EstaBloqueada = true;
                    await _tarjetaRepository.ActualizarAsync(tarjeta);
                    TempData["Error"] = "Tarjeta bloqueada por superar la cantidad de intentos permitidos.";
                    return RedirectToAction("Error");
                }
                else
                {
                    ViewBag.IntentosFallidos = tarjeta.IntentosFallidos;
                    TempData["Error"] = $"PIN incorrecto.";
                }
                await _tarjetaRepository.ActualizarAsync(tarjeta);
                return View("IngresarPIN");
            }

            tarjeta.IntentosFallidos = 0;
            await _tarjetaRepository.ActualizarAsync(tarjeta); 

            return RedirectToAction("Index", "Operaciones");


        }

    }
    
}
