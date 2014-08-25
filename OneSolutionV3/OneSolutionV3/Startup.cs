using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OneSolutionV3.Startup))]
namespace OneSolutionV3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
