using BLWTraining.Models;
using Telerik.OpenAccess;

namespace BLWTraining.DataAccess.Service
{
    public class TrainingSessionSubscriptionStore : Repository<TraningSessionSubscriptions>
    {
        public TrainingSessionSubscriptionStore(OpenAccessContext ctx) : base(ctx)
        {
        }
    }
}