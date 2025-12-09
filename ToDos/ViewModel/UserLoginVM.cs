using System.ComponentModel.DataAnnotations;

namespace ToDos.ViewModel
{
    public class UserLoginVM
    {
        [Required(ErrorMessage ="login obligatoire")]
        public string Login { get; set; }
        [Required(ErrorMessage ="mot de passe obligatoire")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
