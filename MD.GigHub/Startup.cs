using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MD.GigHub.Startup))]
namespace MD.GigHub
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
