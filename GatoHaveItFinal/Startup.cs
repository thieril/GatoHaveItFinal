using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GatoHaveItFinal.Startup))]
namespace GatoHaveItFinal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
