using Microsoft.AspNetCore.Mvc;

namespace ASP_LAB_8.Controllers
{
    public class CookieController : Controller
    {
        public IActionResult SetCookie(string value)
        {
            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Append("MyCookie", value, option);
            return Content("Кука встановлена!");
        }

        public IActionResult GetCookie()
        {
            var value = Request.Cookies["MyCookie"];
            return Content("Значення куки: " + value);
        }
    }
}
