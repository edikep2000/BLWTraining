using System;
using System.ComponentModel.DataAnnotations;

namespace BlwTraining.ViewModels
{
    public class TrainingSessionSubscriptionViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "User")]
        public int UserId { get; set; }

        [Required]
        [Display(Name = "Training Session")]
        public int TraniningSessionId { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }
    }
}