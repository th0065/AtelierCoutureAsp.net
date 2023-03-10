using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcGlAtelier2023.Startup))]
namespace MvcGlAtelier2023
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
