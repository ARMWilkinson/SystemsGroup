using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SystemsGroup.Startup))]
namespace SystemsGroup
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
