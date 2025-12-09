using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using ToDos.Filters;
using ToDos.Mappers;
using ToDos.Models;
using ToDos.ViewModel;

namespace ToDos.Controllers
{
    [LogFilter]
    public class TodosController : Controller
    {
        
        public IActionResult Index()
        {
            List<Todo> list = new List<Todo>();
            if (HttpContext.Session.GetString("Todos") != null)
            {
                list = JsonSerializer.Deserialize<List<Todo>>(HttpContext.Session.GetString("Todos"));
            }
            return View(list);
        }
        [AuthFilter]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(ToDoAddVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            List<Todo> todos = new List<Todo>();
            Todo todo = TodoMapper.GetTodofromTodoAddVM(vm);
            todos.Add(todo);

            return RedirectToAction(nameof(Index));
        }
    }
}
