using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HotelsDotCom.Startup))]
namespace HotelsDotCom
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
