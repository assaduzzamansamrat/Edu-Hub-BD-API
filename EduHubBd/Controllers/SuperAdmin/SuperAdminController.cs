using EduHubEntity;
using EduHubInterface;
using Microsoft.AspNetCore.Mvc;

namespace EduHubBd.Controllers.SuperAdmin
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuperAdminController : ControllerBase
    {
        private IUserRepository userRepo;

        public SuperAdminController(IUserRepository userRepo)
        {
            this.userRepo = userRepo;
        }
        [Route("GetAllUsers")]
        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<User> users = await this.userRepo.GetAllAsync();
                return Ok(new { users });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [Route("GetAllUsersBySearch")]
        [HttpGet()]
        public async Task<IActionResult> GetAllBySearch(string searchText, string searchFilter, int pageNumber, int pageSize)
        {
            try
            {
                List<User> users = await this.userRepo.SearchAsync(searchText, searchFilter, pageNumber, pageSize);
                return Ok(new { users });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
