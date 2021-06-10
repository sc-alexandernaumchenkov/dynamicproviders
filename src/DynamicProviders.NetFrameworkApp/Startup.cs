using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using DynamicProviders.NetFrameworkApp;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace DynamicProviders.NetFrameworkApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ServicePointManager.ServerCertificateValidationCallback =
                delegate (
                    object s,
                    X509Certificate certificate,
                    X509Chain chain,
                    SslPolicyErrors sslPolicyErrors
                )
                {
                    return true;

                };
            ConfigureAuth(app);
        }
    }
}
