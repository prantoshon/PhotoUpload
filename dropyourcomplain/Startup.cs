using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(dropyourcomplain.Startup))]
namespace dropyourcomplain
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
