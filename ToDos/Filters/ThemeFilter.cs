using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ToDos.Filters
{
    public class ThemeFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var http = context.HttpContext;

            // Lire le cookie
            string theme = http.Request.Cookies["Theme"] ?? "light";

            // Récupérer le contrôleur en cours
            var controller = context.Controller as Controller;
            if (controller != null)
            {
                controller.ViewData["Theme"] = theme;
            }
        }
    }
}
