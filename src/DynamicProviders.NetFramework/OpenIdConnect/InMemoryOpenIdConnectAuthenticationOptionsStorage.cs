using System.Collections.Generic;
using Microsoft.Owin.Security.OpenIdConnect;

namespace DynamicProviders.OpenIdConnect
{
    public class InMemoryOpenIdConnectAuthenticationOptionsStorage : IOptionsStorage<OpenIdConnectAuthenticationOptions>
    {
        public IEnumerable<OpenIdConnectAuthenticationOptions> GetOptions()
        {
            yield return new OpenIdConnectAuthenticationOptions("idsrv2")
            {
                //AuthenticationMode = AuthenticationMode.Passive,
                Authority = "https://idsrv2",
                ClientId = "mvc",
                ClientSecret = "secret",
                //RequireHttpsMetadata = false,
                RedeemCode = true,
                SaveTokens = true,
                RedirectUri = "https://localhost:44339/signin-oidc",
                //UsePkce = false,
                // SignInAsAuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                //CallbackPath = new PathString("/oidc-idsrv1"),
            };

            yield return new OpenIdConnectAuthenticationOptions("idsrv3")
            {
                //AuthenticationMode = AuthenticationMode.Passive,
                Authority = "https://idsrv2",
                ClientId = "mvc",
                ClientSecret = "secret",
                //RequireHttpsMetadata = false,
                RedeemCode = true,
                SaveTokens = true,
                RedirectUri = "https://localhost:44339/signin-oidc",
                //UsePkce = false,
                // SignInAsAuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                //CallbackPath = new PathString("/oidc-idsrv1"),
            };
        }
    }
}
