using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using TestGenerator.Core.Models;
using TestGenerator.Persistence;

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
