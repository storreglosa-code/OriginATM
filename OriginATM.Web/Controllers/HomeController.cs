using Microsoft.AspNetCore.Mvc;
using OriginATM.Web.Models;
using System.Diagnostics;

namespace OriginATM.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        

    }
}
