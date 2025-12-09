using Microsoft.AspNetCore.Mvc.Filters;

namespace ToDos.Filters
{
    public class LogFilter: ActionFilterAttribute
    {
        private readonly string logFilePath = "Logs/actions.log";

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var http = context.HttpContext;

            // Récupérer le login depuis la session
            string user = http.Session.GetString("UserLogin") ?? "Anonymous";

            // Nom du contrôleur et de l'action
            string controller = context.RouteData.Values["controller"]?.ToString();
            string action = context.RouteData.Values["action"]?.ToString();

            // Date et heure
            string date = DateTime.Now.ToString("yyyy-MM-dd / HH:mm:ss");

            // Ligne du log
            string line = $"{date} – {user} – {controller} – {action}";

            // S'assurer que le dossier existe
            Directory.CreateDirectory("Logs");

            // Écriture dans le fichier
            File.AppendAllText(logFilePath, line + Environment.NewLine);
        }
    }
}
