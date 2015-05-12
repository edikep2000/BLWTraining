using System;
using System.Linq;
using System.Threading.Tasks;
using BLWTraining.Models;
using Microsoft.AspNet.Identity;
using Telerik.OpenAccess;

namespace BLWTraining.DataAccess.Service
{
    public class RoleStore : Repository<IdentityRole>, IQueryableRoleStore<IdentityRole, int>
    {
        public RoleStore(OpenAccessContext ctx) : base(ctx)
        {
        }

        public void Dispose()
        {
           
        }

        public Task CreateAsync(IdentityRole role)
        {
            if(role == null)
                throw new ArgumentNullException("role");
            Insert(role);
            return Task.FromResult<Object>(null);
        }

        public Task UpdateAsync(IdentityRole role)
        {
            if (role == null)
                throw new ArgumentNullException("role");
            this.Context.AttachCopy(role);

            return Task.FromResult(0);
        }

        public Task DeleteAsync(IdentityRole role)
        {
            if (role == null)
                throw new ArgumentNullException("role");
            Delete(role);
            return Task.FromResult<Object>(null);
        }

        public Task<IdentityRole> FindByIdAsync(int roleId)
        {
            var r = Find(i => i.Id == roleId).FirstOrDefault();
            return Task.FromResult(r);
        }

        public Task<IdentityRole> FindByNameAsync(string roleName)
        {
            var r = Find(i => i.Name == roleName).FirstOrDefault();
            return Task.FromResult(r);
        }

        public IQueryable<IdentityRole> Roles
        {
            get
            {
                return Context.GetAll<IdentityRole>();
            }
        }
    }
}