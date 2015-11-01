using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lost.UI.Startup))]
namespace Lost.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
