using System;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using BlwTraining;
using BlwTraining.App_Start;
using BLWTraining.DataAccess.Service;
using BLWTraining.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataProtection;
using Owin;
using Telerik.OpenAccess;
using IdentityRole = BLWTraining.Models.IdentityRole;

[assembly: OwinStartupAttribute(typeof(Startup))]
namespace BlwTraining
{
    public partial class Startup
    {
        internal static IDataProtectionProvider DataProtectionProvider { get; set; }
        public void Configuration(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            //register web abstractions
            builder.RegisterModule<AutofacWebTypesModule>();
            //register Model Binders
            builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinderProvider();
            //register filter providers
            builder.RegisterFilterProvider();
            //register persistence services
            var persistenceAssembly = typeof(RoleStore).Assembly;
            builder.RegisterAssemblyTypes(persistenceAssembly)
                .Where(i => i.Name.EndsWith("Store"))
                .InstancePerRequest();
            builder.RegisterType<UserStore>().As<IUserStore<BLWTraining.Models.IdentityUser, Int32>>().InstancePerRequest();
            builder.RegisterType<UserStore>().As<IUserRoleStore<BLWTraining.Models.IdentityUser, Int32>>().InstancePerRequest();
            builder.RegisterType<UserStore>().As<IUserClaimStore<BLWTraining.Models.IdentityUser, Int32>>().InstancePerRequest();
            builder.RegisterType<UserStore>().As<IUserPasswordStore<BLWTraining.Models.IdentityUser, Int32>>().InstancePerRequest();
            builder.RegisterType<UserStore>().As<IUserSecurityStampStore<BLWTraining.Models.IdentityUser, Int32>>().InstancePerRequest();
            builder.RegisterType<UserStore>().As<IUserEmailStore<BLWTraining.Models.IdentityUser, Int32>>().InstancePerRequest();
            builder.RegisterType<UserStore>().As<IUserPhoneNumberStore<BLWTraining.Models.IdentityUser, Int32>>().InstancePerRequest();
            builder.RegisterType<UserStore>().As<IUserTwoFactorStore<BLWTraining.Models.IdentityUser, Int32>>().InstancePerRequest();
            builder.RegisterType<UserStore>().As<IUserLockoutStore<BLWTraining.Models.IdentityUser, Int32>>().InstancePerRequest();
            builder.RegisterType<UserStore>().As<IUserLoginStore<BLWTraining.Models.IdentityUser, Int32>>().InstancePerRequest();
            builder.RegisterType<UserStore>().As<IQueryableUserStore<BLWTraining.Models.IdentityUser, Int32>>().InstancePerRequest();
            builder.RegisterType<RoleStore>().As<IQueryableRoleStore<IdentityRole, int>>().InstancePerRequest();


            builder.RegisterType<EntitiesModel>().As<OpenAccessContext>().InstancePerRequest();
            builder.Register(t => HttpContext.Current.GetOwinContext().Authentication).As<IAuthenticationManager>();
            builder.RegisterType<ApplicationSignInManager>().AsSelf();
            builder.RegisterType<ApplicationUserManager>().AsSelf();
            //register owin integration
            var container = builder.Build();
            var dependencyResolver = new AutofacDependencyResolver(container);
            DependencyResolver.SetResolver(dependencyResolver);
            ConfigureAuth(app);
            app.UseAutofacMiddleware(container);
            app.UseAutofacMvc();
        }
    }
}
