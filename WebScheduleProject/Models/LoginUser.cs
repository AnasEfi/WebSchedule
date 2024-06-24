using System.ComponentModel.DataAnnotations;

namespace WebScheduleProject.Models
{
    public class LoginUser
    {
        [Required]
        [Display(Name = "Логин")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
