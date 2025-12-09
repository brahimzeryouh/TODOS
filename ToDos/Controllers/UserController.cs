using Microsoft.AspNetCore.Mvc;
using ToDos.ViewModel;

namespace ToDos.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(UserLoginVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (vm.Login == "admin" && vm.Password == "admin")
            {
                HttpContext.Session.SetString("Login", vm.Login);
                HttpContext.Session.SetString("Password", vm.Password);

                // Redirection vers la page d'accueil sécurisée
                return RedirectToAction("Add", "Todos");
            }

            return View();
        }
    }
}
