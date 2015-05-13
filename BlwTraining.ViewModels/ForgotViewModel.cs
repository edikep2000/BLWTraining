using System.ComponentModel.DataAnnotations;

namespace BlwTraining.ViewModels
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}