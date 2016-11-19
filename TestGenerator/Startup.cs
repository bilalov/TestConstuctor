using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestGenerator.Startup))]
namespace TestGenerator
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
