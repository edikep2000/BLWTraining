using BLWTraining.Models;
using Telerik.OpenAccess;

namespace BLWTraining.DataAccess.Service
{
    public class ZoneStore : Repository<Zone>
    {
        public ZoneStore(OpenAccessContext ctx) : base(ctx)
        {
        }
    }
}