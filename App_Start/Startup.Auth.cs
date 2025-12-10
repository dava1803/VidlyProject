using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System.Configuration;
using VidlyProject.Models;

namespace VidlyProject
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

            // Main application cookie
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });

            // REQUIRED for external login like Facebook / Google
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Facebook login
            app.UseFacebookAuthentication(
                appId: ConfigurationManager.AppSettings["FacebookAppId"],
                appSecret: ConfigurationManager.AppSettings["FacebookAppSecret"]
            );
        }
    }
}
