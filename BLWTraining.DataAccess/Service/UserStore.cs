using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BLWTraining.Models;
using Microsoft.AspNet.Identity;
using Telerik.OpenAccess;

namespace BLWTraining.DataAccess.Service
{
    public class UserStore : Repository<IdentityUser>,
        IUserRoleStore<IdentityUser, Int32>,
        IUserClaimStore<IdentityUser, Int32>,
        IUserPasswordStore<IdentityUser, Int32>,
        IUserSecurityStampStore<IdentityUser, Int32>,
        IUserEmailStore<IdentityUser, Int32>,
        IUserPhoneNumberStore<IdentityUser, Int32>,
        IUserTwoFactorStore<IdentityUser, Int32>,
        IUserLockoutStore<IdentityUser, Int32>,
        IUserLoginStore<IdentityUser, Int32>,
        IQueryableUserStore<IdentityUser, Int32>,
        IUserStore<IdentityUser, Int32>
    {
        public UserStore(OpenAccessContext ctx) : base(ctx)
        {
        }

        public void Dispose()
        {
        }

        public Task CreateAsync(IdentityUser user)
        {
            if(user == null)
                throw new ArgumentNullException("user");
            Insert(user);
            return Task.FromResult<Object>(null);
        }

        public Task UpdateAsync(IdentityUser user)
        {
            if(user == null)
                throw new ArgumentNullException("user");
            Context.AttachCopy(user);
            return Task.FromResult<Object>(null);
        }

        public Task DeleteAsync(IdentityUser user)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            Delete(user);
            return Task.FromResult<Object>(null);
        }

        public Task<IdentityUser> FindByIdAsync(int userId)
        {
            var s = GetSingle(userId);
            return Task.FromResult(s);
        }

        public Task<IdentityUser> FindByNameAsync(string userName)
        {
            var s = Find(i => i.EmailAddress == userName).FirstOrDefault();
            return Task.FromResult(s);
        }

        public Task AddToRoleAsync(IdentityUser user, string roleName)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            if (roleName == null)
                throw new ArgumentNullException("roleName");
            var role = Context.GetAll<IdentityRole>().FirstOrDefault(i => i.Name == roleName);
            if(role != null && user.IdentityUserInRoles.All(r => r.IdentityRole.Id != role.Id))
                user.IdentityUserInRoles.Add(new IdentityUserInRole()
                {
                    RoleId = role.Id,
                    UserId = user.Id
                });
            return Task.FromResult(0);
        }

        public Task RemoveFromRoleAsync(IdentityUser user, string roleName)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            if (roleName == null)
                throw new ArgumentNullException("roleName");
            var role = user.IdentityUserInRoles.FirstOrDefault(i => i.IdentityRole.Name == roleName);
            if (role != null && user.IdentityUserInRoles.Any(r => r.IdentityRole.Id != role.Id))
                user.IdentityUserInRoles.Remove(role);
            return Task.FromResult(0);
        }

        public Task<IList<string>> GetRolesAsync(IdentityUser user)
        {
           if(user == null)
               throw new ArgumentNullException("user");
            var s = user.IdentityUserInRoles.Select(i => i.IdentityRole.Name).ToList();
            return Task.FromResult<IList<String>>(s);
        }

        public Task<bool> IsInRoleAsync(IdentityUser user, string roleName)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            if (roleName == null)
                throw new ArgumentNullException("roleName");
            var s = user.IdentityUserInRoles.Any(i => i.IdentityRole.Name == roleName);
            return Task.FromResult(s);
        }

        public Task<IList<Claim>> GetClaimsAsync(IdentityUser user)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            IList<Claim> claims = Context.GetAll<IdentityUserClaim>().Where(c => c.UserId == user.Id).Select(c => new Claim(c.ClaimType, c.ClaimValue)).ToList();
            return Task.FromResult(claims);

        }

        public Task AddClaimAsync(IdentityUser user, Claim claim)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            if (claim == null)
            {
                throw new ArgumentNullException("claim");
            }

            var alreadyHasClaim =
                Find(
                    i =>
                        i.IdentityUserClaims.Any(
                            j => j.UserId == user.Id && j.ClaimType == claim.Type && j.ClaimValue == claim.Value)).Any();


            if (!alreadyHasClaim)
            {
                user.IdentityUserClaims.Add(new IdentityUserClaim()
                {
                    ClaimType = claim.Type,
                    ClaimValue = claim.Value,
                    UserId = user.Id
                });
            }
            return Task.FromResult(0);

        }

        public Task RemoveClaimAsync(IdentityUser user, Claim claim)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            if (claim == null)
            {
                throw new ArgumentNullException("claim");
            }

            var userClaim =
                Context.GetAll<IdentityUserClaim>()
                    .FirstOrDefault(i => i.UserId == user.Id && i.ClaimType == claim.Type && i.ClaimValue == claim.Value);
            if(userClaim != null)
                Context.Delete(userClaim);
            return Task.FromResult(0);
        }

        public Task SetPasswordHashAsync(IdentityUser user, string passwordHash)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            user.PasswordHash = passwordHash;
            return Task.FromResult(0);
        }

        public Task<string> GetPasswordHashAsync(IdentityUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            return Task.FromResult(user.PasswordHash);
        }

        public Task<bool> HasPasswordAsync(IdentityUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            return Task.FromResult(!string.IsNullOrEmpty(user.PasswordHash));
        }

        public Task SetSecurityStampAsync(IdentityUser user, string stamp)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            if (stamp == null)
            {
                throw new ArgumentNullException("stamp");
            }
            user.SecurityStamp = stamp;
            return Task.FromResult(0);
        }

        public Task<string> GetSecurityStampAsync(IdentityUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            return Task.FromResult(user.SecurityStamp);
        }

        public Task SetEmailAsync(IdentityUser user, string email)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            if (email == null)
            {
                throw new ArgumentNullException("email");
            }
            user.EmailAddress = email;
            return Task.FromResult(0);
        }

        public Task<string> GetEmailAsync(IdentityUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            return Task.FromResult(user.EmailAddress);
        }

        public Task<bool> GetEmailConfirmedAsync(IdentityUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            return Task.FromResult(user.EmailConfirmed);
        }

        public Task SetEmailConfirmedAsync(IdentityUser user, bool confirmed)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            user.EmailConfirmed = confirmed;
            return Task.FromResult(0);
        }

        public Task<IdentityUser> FindByEmailAsync(string email)
        {
            return Task.FromResult(Find(i => i.EmailAddress == email).FirstOrDefault());
        }

        public Task SetPhoneNumberAsync(IdentityUser user, string phoneNumber)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            user.PhoneNumber = phoneNumber;
            return Task.FromResult(0);
        }

        public Task<string> GetPhoneNumberAsync(IdentityUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            return Task.FromResult(user.PhoneNumber);
        }

        public Task<bool> GetPhoneNumberConfirmedAsync(IdentityUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            return Task.FromResult(user.PhoneNumberConfirmed);
        }

        public Task SetPhoneNumberConfirmedAsync(IdentityUser user, bool confirmed)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            user.PhoneNumberConfirmed = confirmed;
            return Task.FromResult(0);
        }

        public Task SetTwoFactorEnabledAsync(IdentityUser user, bool enabled)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            user.TwoFactorEnabled = enabled;
            return Task.FromResult(0);
        }

        public Task<bool> GetTwoFactorEnabledAsync(IdentityUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            return Task.FromResult(user.TwoFactorEnabled);
        }

        public Task<DateTimeOffset> GetLockoutEndDateAsync(IdentityUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            if (user.LockOutEndDateUtc.HasValue)
            {
                return Task.FromResult(new DateTimeOffset(DateTime.SpecifyKind(user.LockOutEndDateUtc.Value, DateTimeKind.Utc)));
            }
            return Task.FromResult(new DateTimeOffset());

        }

        public Task SetLockoutEndDateAsync(IdentityUser user, DateTimeOffset lockoutEnd)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            if (lockoutEnd == DateTimeOffset.MinValue)
            {
                user.LockOutEndDateUtc = null;
            }
            else
            {
                user.LockOutEndDateUtc = lockoutEnd.UtcDateTime;
            }

            return Task.FromResult(0);

        }

        public Task<int> IncrementAccessFailedCountAsync(IdentityUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            user.AccessFailedCount++;

            return Task.FromResult(user.AccessFailedCount);
        }

        public Task ResetAccessFailedCountAsync(IdentityUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            user.AccessFailedCount = 0;

            return Task.FromResult(0);

        }

        public Task<int> GetAccessFailedCountAsync(IdentityUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            return Task.FromResult(user.AccessFailedCount);

        }

        public Task<bool> GetLockoutEnabledAsync(IdentityUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            return Task.FromResult(user.LockOutEnabled);

        }

        public Task SetLockoutEnabledAsync(IdentityUser user, bool enabled)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            user.LockOutEnabled = enabled;

            return Task.FromResult(0);

        }

        public Task AddLoginAsync(IdentityUser user, UserLoginInfo login)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            if (login == null)
            {
                throw new ArgumentNullException("login");
            }

            user.IdentityUserLogins.Add(new IdentityUserLogin
            {
                UserId = user.Id,
                ProviderKey = login.ProviderKey,
                LoginProvider = login.LoginProvider
            });

            return Task.FromResult(0);
        }

        public Task RemoveLoginAsync(IdentityUser user, UserLoginInfo login)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            if (login == null)
            {
                throw new ArgumentNullException("login");
            }

            var provider = login.LoginProvider;
            var key = login.ProviderKey;
            var loginEntity = user.IdentityUserLogins.SingleOrDefault(l => l.LoginProvider == provider && l.ProviderKey == key);

            if (loginEntity != null)
            {
                user.IdentityUserLogins.Remove(loginEntity);
            }

            return Task.FromResult(0);

        }

        public Task<IList<UserLoginInfo>> GetLoginsAsync(IdentityUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            IList<UserLoginInfo> result = user.IdentityUserLogins.Select(l => new UserLoginInfo(l.LoginProvider, l.ProviderKey)).ToList();
            return Task.FromResult(result);
        }

        public Task<IdentityUser> FindAsync(UserLoginInfo login)
        {
            if (login == null)
            {
                throw new ArgumentNullException("login");
            }

            var provider = login.LoginProvider;
            var key = login.ProviderKey;
            var userLogin = Context.GetAll<IdentityUserLogin>().FirstOrDefault(l => l.LoginProvider == provider && l.ProviderKey == key);

            if (userLogin == null)
            {
                return Task.FromResult<IdentityUser>(null);
            }

            var user = Find(i => i.IdentityUserLogins.Any(j => j.UserId == userLogin.UserId)).FirstOrDefault();
            return Task.FromResult(user);

        }

        public IQueryable<IdentityUser> Users
        {
            get
            {
                return this.Context.GetAll<IdentityUser>();
            }
        }
    }

}