using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SRMS_Client.Models;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace SRMS_Client.Controllers
{

    public class LoginController : Controller
    {
        //protected const string SessionEmail = "_Email";
        //protected const string SessionUserId = "_UserId";
        //protected const string SessionUserRole = "_UserRole";
        //protected const string SessionAccessToken = "_AccessToken";
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginModel loginModel)
        {
            if (loginModel != null && ModelState.IsValid)
            {
                bool isAuthenticate = false;
                using (var httpClient = new HttpClient())
                {
                    var requestString = JsonConvert.SerializeObject(loginModel);
                    // Setup the HttpClient and make the call and get the relevant data.
                    httpClient.BaseAddress = new Uri("https://localhost:7088");

                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var request = new HttpRequestMessage(HttpMethod.Post, $"/api/Login/Authenticate");
                    request.Content = new StringContent(requestString, System.Text.Encoding.UTF8, "application/json");

                    var response = await httpClient.SendAsync(request);
                    var responseContent = await response.Content.ReadAsStringAsync();

                    LoginModel result = new LoginModel();
                    result = JsonConvert.DeserializeObject<LoginModel>(responseContent);
                    //HttpContext.Session.SetString(SessionEmail, result.EmailAddress);
                    //HttpContext.Session.SetString(SessionAccessToken, result.AccessToken);
                    ClaimsIdentity identity = null;
                    identity = new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.Name,result.EmailAddress),
                        new Claim(ClaimTypes.Role,"User")
                    }, CookieAuthenticationDefaults.AuthenticationScheme);
                    isAuthenticate = true;

                    if (response.IsSuccessStatusCode)
                    {
                        if (isAuthenticate)
                        {
                            //var principal = new ClaimsPrincipal(identity);
                            //var login =  HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                            await HttpContext.SignInAsync(
                            CookieAuthenticationDefaults.AuthenticationScheme,
                            new ClaimsPrincipal(identity),
                            new AuthenticationProperties
                            {
                                IsPersistent = true,
                                AllowRefresh = true,
                                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(365),
                            });
                            return RedirectToAction("Index", "UserDashBoard");
                        }
                    }
                    else
                    {
                        return RedirectToAction("Index", "Login");
                    }


                }
            }
            return RedirectToAction("Index", "Login");
        }
    }
}
