using System;
using System.ComponentModel.DataAnnotations;

namespace BlwTraining.ViewModels
{
    public class TrainingSessionFileViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Tranining Session")]
        public int TrainingSessionId { get; set; }

        [Required]
        [Display(Name = "File Name")]
        public String FileName { get; set; }

        [Display(Name = "FilePath")]
        public String FilePath { get; set; }

        [Display(Name = "File Type")]
        public String FileType { get; set; }

        [Display(Name = "File Size")]
        public String FileSize { get; set; }

        [Display(Name = "Allow Downloads")]
        public bool IsDownloadable { get; set; }
    }
}