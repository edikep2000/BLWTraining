using System;

namespace BlwTraining.ViewModels
{
    public class TrainingSessionFileListModel
    {
        public int Id { get; set; }

        public String FileName { get; set; }

        public String FileType { get; set; }

        public Boolean IsDownloadable { get; set; }
    }
}