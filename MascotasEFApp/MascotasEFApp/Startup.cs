using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MascotasEFApp.Startup))]
namespace MascotasEFApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
