using EduHubEntity;
using EduHubInterface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduHubBd.Controllers.SuperAdmin
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SuperAdminDashBoardController : ControllerBase
    {
        private IUserRepository userRepo;

        public SuperAdminDashBoardController(IUserRepository _userRepo)
        {
            this.userRepo = _userRepo;
        }

        [Route("GetTotalUsersCount")]
        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<User> users = await this.userRepo.GetAllAsync();
                int usersCount = users.Count();
                return Ok(new { usersCount });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
