using Microsoft.AspNetCore.Mvc;
using OriginATM.Infraestructura;

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

    }
}
