using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PMA.WebMVC.Startup))]
namespace PMA.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
