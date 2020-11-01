using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Rovers4.Areas.Identity.IdentityHostingStartup))]
namespace Rovers4.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}