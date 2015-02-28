using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Entity_Test.Startup))]
namespace Entity_Test
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
