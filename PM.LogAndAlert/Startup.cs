using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PM.LogAndAlert.Startup))]
namespace PM.LogAndAlert
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
