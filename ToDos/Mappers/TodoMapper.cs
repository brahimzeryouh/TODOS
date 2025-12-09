using ToDos.Models;
using ToDos.ViewModel;

namespace ToDos.Mappers
{
    public class TodoMapper
    {
        public static Todo GetTodofromTodoAddVM(ToDoAddVM vm)
        {
            Todo todo=new Todo();

            todo.Libelle = vm.Libelle;
            todo.Description = vm.Description;
            todo.DateLimite = vm.DateLimite;
            todo.State = vm.State;

            return todo;
        }
    }
}
