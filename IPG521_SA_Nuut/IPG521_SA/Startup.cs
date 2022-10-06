using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IPG521_SA.Startup))]
namespace IPG521_SA
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
