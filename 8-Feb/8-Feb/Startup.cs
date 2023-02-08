using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_8_Feb.Startup))]
namespace _8_Feb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
