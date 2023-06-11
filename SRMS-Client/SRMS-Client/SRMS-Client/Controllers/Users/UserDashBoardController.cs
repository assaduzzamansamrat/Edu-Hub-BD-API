using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SRMS_Client.Controllers.Users
{
    [Authorize(Roles = "User")]
    public class UserDashBoardController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
