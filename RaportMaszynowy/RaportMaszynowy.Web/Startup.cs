using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RaportMaszynowy.Web.Startup))]
namespace RaportMaszynowy.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
