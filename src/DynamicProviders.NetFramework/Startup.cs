using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DynamicProviders.NetFramework.Startup))]
namespace DynamicProviders.NetFramework
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
