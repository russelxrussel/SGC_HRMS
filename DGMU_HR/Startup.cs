using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DGMU_HR.Startup))]
namespace DGMU_HR
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            //ConfigureAuth(app);
        }
    }
}
