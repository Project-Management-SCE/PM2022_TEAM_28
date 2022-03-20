using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HolyWebi.Startup))]
namespace HolyWebi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
