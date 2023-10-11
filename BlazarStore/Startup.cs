using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BlazarStore.Startup))]
namespace BlazarStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
