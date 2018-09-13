using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RestaurantGuide.Web.Startup))]
namespace RestaurantGuide.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
