using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(To_DoList.Startup))]
namespace To_DoList
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
