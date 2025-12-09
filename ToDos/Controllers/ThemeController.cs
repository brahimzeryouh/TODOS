using Microsoft.AspNetCore.Mvc;

namespace ToDos.Controllers
{
    public class ThemeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
       
        public IActionResult Change(string mode)
        {
            if (mode != "dark" && mode != "light")
                mode = "light";

            Response.Cookies.Append("Theme", mode, new CookieOptions
            {
                Expires = DateTime.Now.AddDays(30)
            });

            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}
