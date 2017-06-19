using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TodaSupportWeb.Startup))]
namespace TodaSupportWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
