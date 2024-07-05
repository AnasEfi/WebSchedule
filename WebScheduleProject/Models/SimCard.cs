using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebScheduleProject.Models
{
    public class SimCard
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "SimNumber is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        [Display(Name = "Phone Number")]

        [StringLength(20)]
        public string? SimNumber { get; set; } 

        public List<Service> Services { get; set; } = new();

        [Length(0,20)]
        [Required(ErrorMessage = "Phone provider is required")]
        public string? Provider { get; set; }
        public int UserId { get; set; }
    }
}
