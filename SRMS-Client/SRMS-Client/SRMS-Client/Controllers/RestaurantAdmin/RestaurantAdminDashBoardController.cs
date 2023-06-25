using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SRMS_Client.Controllers.RestaurantAdmin
{
    [Authorize(Roles = "RestaurantAdmin")]
    public class RestaurantAdminDashBoardController : Controller
    {
        public async Task<IActionResult> Index()
        {
            ViewBag.SubPageName = "DashBoard";
            ViewBag.MainPageName = "DashBoard";
            return View("~/Views/RestaurantAdmin/RestaurantAdminDashBoard/Index.cshtml");
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }
    }
}
