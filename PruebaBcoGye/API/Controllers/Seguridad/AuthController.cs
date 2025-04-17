using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Seguridad
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
