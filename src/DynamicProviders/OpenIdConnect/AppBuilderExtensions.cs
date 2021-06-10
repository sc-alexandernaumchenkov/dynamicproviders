using Microsoft.Owin.Security.OpenIdConnect;
using Owin;

namespace DynamicProviders.OpenIdConnect
{
    public static class AppBuilderExtensions
    {
        public static IAppBuilder UseDynamicOpenIdConnectAuthenticationMiddleware(this IAppBuilder builder, 
            IOptionsStorage<OpenIdConnectAuthenticationOptions> optionsStorage)
        {
            return builder
                .Use<RuntimeMiddleware<OpenIdConnectAuthenticationMiddleware, OpenIdConnectAuthenticationOptions>>(
                    builder.New(), optionsStorage);
        }
    }
}