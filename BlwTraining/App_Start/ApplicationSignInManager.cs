using System.Security.Claims;
using System.Threading.Tasks;
using BLWTraining.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace BlwTraining.App_Start
{
    public class ApplicationSignInManager : SignInManager<IdentityUser, int>
    {
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(IdentityUser user)
        {
            return user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
        }
    }
}