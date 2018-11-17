using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PurchaseSystem.Startup))]
namespace PurchaseSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
