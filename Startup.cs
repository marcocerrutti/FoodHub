using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FoodHub.Startup))]
namespace FoodHub
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
