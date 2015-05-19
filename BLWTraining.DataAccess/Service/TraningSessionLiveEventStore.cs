using BLWTraining.Models;
using Telerik.OpenAccess;

namespace BLWTraining.DataAccess.Service
{
    public class TraningSessionLiveEventStore : Repository<TrainingSessionLiveEvents>
    {
        public TraningSessionLiveEventStore(OpenAccessContext ctx) : base(ctx)
        {
        }
    }
}