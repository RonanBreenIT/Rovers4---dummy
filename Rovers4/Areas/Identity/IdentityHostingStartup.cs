using Microsoft.AspNetCore.Hosting;
using System;

[assembly: HostingStartup(typeof(Rovers4.Areas.Identity.IdentityHostingStartup))]
namespace Rovers4.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}