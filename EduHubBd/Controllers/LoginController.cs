using EduHubEntity;
using EduHubEntity.LoginModel;
using EduHubInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EduHubBd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase

    {

        private readonly IUserRepository userRepo;
        private IConfiguration _configuration;
        public LoginController(IUserRepository _userRepo, IConfiguration configuration)
        {
            this.userRepo = _userRepo;
            this._configuration = configuration;
        }
        [HttpPost]
        [Route("Authenticate")]
        public async Task<IActionResult> Authenticate(LoginModel loginModel)
        {
            if (loginModel != null)
            {
                User user = await this.userRepo.GetUserByEmailAndPassword(loginModel.EmailAddress, loginModel.Password);
                if (user == null)
                {
                    return BadRequest("Invalid Credentials");
                }
                else
                {
                    loginModel.UserMessage = "Login Success";

                    var claims = new[] {
                        new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                      
                        new Claim("DisplayName", user.FirstName+' '+user.LastName),                       
                        new Claim("Email", user.EmailAddress)
                    };


                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);


                    loginModel.AccessToken = new JwtSecurityTokenHandler().WriteToken(token);

                    return Ok(loginModel);
                }
            }
            else
            {
                return BadRequest("No Data Posted");
            }
        }

    }
}
