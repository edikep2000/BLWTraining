using System;
using System.ComponentModel.DataAnnotations;

namespace BlwTraining.ViewModels
{
    public class ZoneViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Zone Name")]
        public String Name { get; set; }
    }
}