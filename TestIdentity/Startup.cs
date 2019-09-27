using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using TestIdentity.Identity;

[assembly: OwinStartup(typeof(TestIdentity.Startup))]

namespace TestIdentity
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions() { AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie, LoginPath = new PathString("/Account/Login") });
            this.CreateRolesAndUser();
        }

        private void CreateRolesAndUser()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>());
            var appDbContext = new ApplicationDBContext();
            var appUserStore = new ApplicationUserStore(appDbContext);
            var userManager = new ApplicationUserManager(appUserStore);
            // admin default value
            if(! roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }
            if(userManager.FindByName("Admin")==null)
            {
                var user = new ApplicationUser();
                user.UserName = "Admin";
                user.Email = "Admin@gmail.com";
                string password = "admin123";
                var chkuser = userManager.Create(user, password);
                
                if(chkuser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Admin");
                }
            }
            // Manager Default Value
            if (!roleManager.RoleExists("Manager"))
            {
                var role = new IdentityRole();
                role.Name = "Manager";
                roleManager.Create(role);
            }
            if (userManager.FindByName("Manager") == null)
            {
                var user = new ApplicationUser();
                user.UserName = "Manager";
                user.Email = "Manager@gmail.com";
                string password = "manager123";
                var chkuser = userManager.Create(user, password);

                if (chkuser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Manager");
                }
            }
            // Customer 
            if (!roleManager.RoleExists("Customer"))
            {
                var role = new IdentityRole();
                role.Name = "Customer";
                roleManager.Create(role);
            }
        }
    }
}
