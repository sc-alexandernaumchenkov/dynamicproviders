using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DynamicProviders.NetFramework.Startup))]
namespace DynamicProviders.NetFramework
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
