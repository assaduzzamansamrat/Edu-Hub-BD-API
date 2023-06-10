using EduHubEntity;
using EduHubInterface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduHubBd.Controllers.RestaurantAdmins
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RestaurantAdminUsersController : ControllerBase
    {
        private IUserRepository userRepo;

        public RestaurantAdminUsersController(IUserRepository userRepo)
        {
            this.userRepo = userRepo;
        }
        [Route("CreateUser")]
        [HttpPost]
        public async Task<IActionResult> CreateUser(User user)
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    await this.userRepo.InsertAsync(user);
                    return Ok(new { result = true });
                }
                return Ok(new { result = false });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
