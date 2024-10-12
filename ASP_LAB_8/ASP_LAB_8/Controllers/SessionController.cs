using Microsoft.AspNetCore.Mvc;

namespace ASP_LAB_8.Controllers
{
    public class SessionController : Controller
    {
        public IActionResult SetSession(string value)
        {
            HttpContext.Session.SetString("MySessionKey", value);
            return Content("Сесійне значення встановлено!");
        }

        public IActionResult GetSession()
        {
            var value = HttpContext.Session.GetString("MySessionKey");
            return Content("Сесійне значення: " + value);
        }
    }
}
