using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(XDogServerService.Startup))]

namespace XDogServerService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}