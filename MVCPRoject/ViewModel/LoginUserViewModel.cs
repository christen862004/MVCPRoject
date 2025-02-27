using System.ComponentModel.DataAnnotations;

namespace MVCPRoject.ViewModel
{
    public class LoginUserViewModel
    {
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
