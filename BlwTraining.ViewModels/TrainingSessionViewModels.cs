using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlwTraining.ViewModels
{
    public  class TrainingSessionViewModels
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Session Theme")]
        public String Name { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }


        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; }

        [Required]
        [Display(Name = "Number of Days After End Date Before Archiving")]
        public int DaysAfterEndBeforeArchiving { get; set; }

        [Required]
        [Display(Name = "Brief Description of the purpose of this training Session")]
        public String Description { get; set; }

        [Required]
        [Display(Name = "Maximum Number Of Participants")]
        public int MaximumNumberOfParticipants { get; set; }
    }
}
