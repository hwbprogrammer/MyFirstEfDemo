using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyFirstEFAndMvcDemo.Startup))]
namespace MyFirstEFAndMvcDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
