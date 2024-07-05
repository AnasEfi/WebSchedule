using System.ComponentModel.DataAnnotations;

namespace WebScheduleProject.Models
{
    public class LoginUser
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Логин")]
        public string Email { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}
