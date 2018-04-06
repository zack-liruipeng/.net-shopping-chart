using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Myshop.webUI.Startup))]
namespace Myshop.webUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
