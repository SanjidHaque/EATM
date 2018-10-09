using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EATM.Startup))]
namespace EATM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
