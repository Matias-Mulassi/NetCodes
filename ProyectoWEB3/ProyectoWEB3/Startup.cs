using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProyectoWEB3.Startup))]
namespace ProyectoWEB3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
