using System;
using System.ComponentModel.DataAnnotations;

namespace BlwTraining.ViewModels
{
    public class TrainingSessionLiveEventViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Event Name")]
        public String EventName { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "Live Stream Provider Url")]
        public String FMSUrl { get; set; }

        [Required]
        [Display(Name = "Training Session")]
        public int TrainingSessionId { get; set; }
    }
}