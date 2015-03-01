using Microsoft.Owin;
using Owin;
using System.Data.Entity;

[assembly: OwinStartup(typeof(BeyondThemes.BeyondAdmin.Startup))]
namespace BeyondThemes.BeyondAdmin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            Database.SetInitializer<BeyondThemes.BeyondAdmin.Models.ProjectContext>(new DropCreateDatabaseIfModelChanges<BeyondThemes.BeyondAdmin.Models.ProjectContext>());
        }
    }
}
