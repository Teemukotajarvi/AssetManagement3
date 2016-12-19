using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AssetManagement3.Startup))]
namespace AssetManagement3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
