using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace BLWTraining.Models
{
  public partial  class IdentityUser : IUser<Int32>
  {
      public string UserName
      {
          get { return this._emailAddress; }
          set { this._emailAddress = value; }
      }

      public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<IdentityUser, Int32> manager)
      {
          // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
          var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
          // Add custom user claims here
          return userIdentity;
      }
  }
}
