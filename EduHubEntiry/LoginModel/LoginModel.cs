using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHubEntity.LoginModel
{
    public class LoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string? UserMessage { get; set; }
        public string? AccessToken { get; set; }
    }
}
