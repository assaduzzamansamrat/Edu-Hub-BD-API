using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SRMS_Client.HelperClasses;
using SRMS_Client.HelperClasses.Enum;
using SRMS_Client.Models.Users;
using System.Net.Http.Headers;

namespace SRMS_Client.Controllers.RestaurantAdmin
{
    public class UsersController : Controller
    {
        public async Task<IActionResult> Index()
        {
            ViewBag.SubPageName = "Users";
            ViewBag.MainPageName = "Users";
            return View("~/Views/RestaurantAdmin/Users/Index.cshtml");
        }

        public async Task<IActionResult> CreateUser(User user)
        {
            using (var httpClient = new HttpClient())
            {
                string accessToken = LoggedInUserInfoFromCookie.GetCookie(this, CookieNameEnum.AccessToken.ToString());
                var requestString = JsonConvert.SerializeObject(user);
                // Setup the HttpClient and make the call and get the relevant data.
                httpClient.BaseAddress = new Uri("https://localhost:7088");
                httpClient.DefaultRequestHeaders.Add("Bearer", accessToken);
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var request = new HttpRequestMessage(HttpMethod.Post, $"​/api​/RestaurantAdminUsers​/CreateUser");
                request.Content = new StringContent(requestString, System.Text.Encoding.UTF8, "application/json");

                var response = await httpClient.SendAsync(request);
                var responseContent = await response.Content.ReadAsStringAsync();

                User result = new User();
                result =  JsonConvert.DeserializeObject<User>(responseContent);
                return Json(result);
            }

        }
    }
}
