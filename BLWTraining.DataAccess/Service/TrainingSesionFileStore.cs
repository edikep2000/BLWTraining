using Telerik.OpenAccess;

namespace BLWTraining.DataAccess.Service
{
    public class TrainingSesionFileStore : Repository<TrainingSesionFileStore>
    {
        public TrainingSesionFileStore(OpenAccessContext ctx) : base(ctx)
        {
        }
    }
}