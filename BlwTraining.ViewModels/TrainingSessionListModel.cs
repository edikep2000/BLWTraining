using System;

namespace BlwTraining.ViewModels
{
    public class TrainingSessionListModel
    {
        public int Id { get; set; }

        public String Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int SubscriptionCount { get; set; }

        public int FileCount { get; set; }

        public int LiveEventCount { get; set; }
    }
}