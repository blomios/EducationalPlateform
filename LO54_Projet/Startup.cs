using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LO54_Projet.Startup))]
namespace LO54_Projet
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
