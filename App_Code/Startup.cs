using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Exercice20.Startup))]
namespace Exercice20
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
