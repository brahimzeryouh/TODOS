using System.ComponentModel.DataAnnotations;
using ToDos.Enums;

namespace ToDos.ViewModel
{
    public class ToDoAddVM
    {
        [Required (ErrorMessage ="libelle obligatoire")]
        public string Libelle { get; set; }

        [Required(ErrorMessage ="description obligatoire")]
        public string Description { get; set; }

        [DataType (DataType.Date)]
        public DateTime DateLimite { get; set; }
        public State  State { get; set; }
    }
}
