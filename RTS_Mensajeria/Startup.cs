using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RTS_Mensajeria.Startup))]
namespace RTS_Mensajeria
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
