using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Schrader.Eve.Startup))]
namespace Schrader.Eve
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
#if DEBUG
            ConfigureDatabase();
#endif

            ConfigureAuth(app);
        }
    }
}
