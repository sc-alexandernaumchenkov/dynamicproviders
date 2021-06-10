using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using Owin;

namespace DynamicProviders.NetFrameworkApp
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            //app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);
            
            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });

            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions("idsrv1")
            {
                AuthenticationMode = AuthenticationMode.Passive,
                Authority = "https://idsrv1",
                ClientId = "mvc",
                ClientSecret = "secret",
                AuthenticationType = "code",
                //RequireHttpsMetadata = false,
                RedeemCode = true,
                SaveTokens = true,
                RedirectUri = "https://localhost:44339/signin-oidc",
                UsePkce = false,
               // SignInAsAuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                CallbackPath = new PathString("/oidc-idsrv1"),
            });

            //app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions("idsrv2")
            //{
            //    AuthenticationMode = AuthenticationMode.Passive,
            //    Authority = "https://idsrv2",
            //    ClientId = "mvc",
            //    ClientSecret = "secret",
            //    AuthenticationType = "code",
            //    //RequireHttpsMetadata = false,
            //    RedeemCode = true,
            //    SaveTokens = true,
            //    RedirectUri = "https://localhost:44339/signin-oidc",
            //    UsePkce = false,
            //    SignInAsAuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
            //    CallbackPath = new PathString("/oidc-idsrv2"),
            //});
        }
    }
}