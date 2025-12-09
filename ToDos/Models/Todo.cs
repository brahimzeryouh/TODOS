using System.ComponentModel.DataAnnotations;
using ToDos.Enums;
using ToDos.ViewModel;

namespace ToDos.Models
{
    public class Todo
    {
        
        public string Libelle { get; set; }

        public string Description { get; set; }

        public DateTime DateLimite { get; set; }
        public State State { get; set; }

    }
}
