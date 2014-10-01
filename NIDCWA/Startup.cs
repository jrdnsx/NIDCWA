using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NIDCWA.Startup))]
namespace NIDCWA
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
