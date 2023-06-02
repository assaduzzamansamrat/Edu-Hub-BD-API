using EduHubEntity;
using EduHubInterface;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EduHubBd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]  
    public class SignUpController : ControllerBase
    {
        private IUserRepository userRepo;

        public SignUpController(IUserRepository userRepo)
        {
            this.userRepo = userRepo;
        }
        [Route("SignUp")]
        [HttpPost]
        public async Task<IActionResult> SignUp(User user)
        {
            try
            {
                if(ModelState.IsValid == true)
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
