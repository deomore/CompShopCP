using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CompShop.Startup))]
namespace CompShop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
