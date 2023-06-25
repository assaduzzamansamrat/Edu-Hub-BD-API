using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SRMS_Client.HelperClasses
{
    public static class LoggedInUserInfoFromCookie
    {

        public static void SetCookie(Controller controller, string cookieName, string value)
        {
            try
            {
                var cookieOptions = new CookieOptions();
                controller.Response.Cookies.Append(cookieName, value, cookieOptions);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public static string GetCookie(Controller controller, string cookieName)
        {
            try
            {
                if (controller != null)
                {
                    return controller.Request.Cookies[cookieName];
                }
                return string.Empty;
            }
            catch (Exception ex)
            {

                throw ex;
            }
                       
        }

        public static void RemoveCookie(Controller controller, string key)
        {
            try
            {
                controller.Response.Cookies.Delete(key);
            }
            catch (Exception ex)
            {

                throw ex;
            }          
        }

        public static void RemoveAllcookie(Controller controller)
        {
            try
            {
                if(controller != null)
                {
                    foreach (var cookie in controller.Request.Cookies.Keys)
                    {
                        controller.Response.Cookies.Delete(cookie);
                    }
                }
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


    }
}
