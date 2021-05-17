using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using Owin;

namespace DynamicProviders.NetFrameworkApp
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });

            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions()
            {
                Authority = "https://localhost:5001",
                ClientId = "mvc",
                ClientSecret = "secret",
                AuthenticationType = "code",
                //RequireHttpsMetadata = false,
                RedeemCode = true,
                SaveTokens = true,
                RedirectUri = "https://localhost:44339/signin-oidc",
                UsePkce = false,
                SignInAsAuthenticationType = DefaultAuthenticationTypes.ApplicationCookie
            });
        }
    }
}