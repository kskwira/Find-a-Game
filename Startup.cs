using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Find_a_Game.Startup))]
namespace Find_a_Game
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
