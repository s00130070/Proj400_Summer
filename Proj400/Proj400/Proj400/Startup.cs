using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Proj400.Startup))]
namespace Proj400
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
