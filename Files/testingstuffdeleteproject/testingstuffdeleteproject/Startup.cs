using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(testingstuffdeleteproject.Startup))]
namespace testingstuffdeleteproject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
