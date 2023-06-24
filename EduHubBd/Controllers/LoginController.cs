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

        private readonly IUserRepository _userRepo;
        private readonly IRestaurantAdminRepository _restaurantAdminRepository;
        private IConfiguration _configuration;
        public LoginController(IUserRepository userRepo, IRestaurantAdminRepository restaurantAdminRepository, IConfiguration configuration)
        {
            this._userRepo = userRepo;
            this._configuration = configuration;
            this._restaurantAdminRepository = restaurantAdminRepository;
        }
        [HttpPost]
        [Route("Authenticate")]
        public async Task<IActionResult> Authenticate(LoginModel loginModel)
        {
            if (loginModel != null)
            {
                User user = await this._userRepo.GetUserByEmailAndPassword(loginModel.EmailAddress, loginModel.Password);
                if (user != null)
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
                    loginModel.Role = user.Role;

                    return Ok(loginModel);

                }
                else
                {
                    RestaurantAdmin restaurantAdmin = await this._restaurantAdminRepository.GetRestaurantAdminByEmailAndPassword(loginModel.EmailAddress, loginModel.Password);

                    loginModel.UserMessage = "Login Success";

                    if (restaurantAdmin != null)
                    {
                        var claims = new[] {
                            new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                            new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),

                            new Claim("DisplayName", restaurantAdmin.RestaurantName),
                            new Claim("Email", restaurantAdmin.EmailAddress)
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
                        loginModel.Role = restaurantAdmin.Role;

                        return Ok(loginModel);
                    }

                    return BadRequest("Invalid Credentials");
                }
            }
            else
            {
                return BadRequest("No Data Posted");
            }
        }

    }
}
