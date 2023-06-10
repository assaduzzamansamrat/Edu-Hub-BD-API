using Microsoft.AspNetCore.Mvc;

namespace EduHubBd.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
