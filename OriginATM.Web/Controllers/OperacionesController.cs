using Microsoft.AspNetCore.Mvc;

namespace OriginATM.Web.Controllers
{
    public class OperacionesController : Controller
    {
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
    }
}
