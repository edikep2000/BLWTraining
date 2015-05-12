using Telerik.OpenAccess;

namespace BLWTraining.DataAccess.Service
{
    public class TrainingSessionStore : Repository<TrainingSessionStore>
    {
        public TrainingSessionStore(OpenAccessContext ctx) : base(ctx)
        {
        }
    }
}