using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ScaffoldIdentityTest.Areas.Identity.Data;
using ScaffoldIdentityTest.Models;

[assembly: HostingStartup(typeof(ScaffoldIdentityTest.Areas.Identity.IdentityHostingStartup))]
namespace ScaffoldIdentityTest.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<ScaffoldIdentityTestContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("ScaffoldIdentityTestContextConnection")));

                services.AddDefaultIdentity<ScaffoldIdentityTestUser>()
                    .AddEntityFrameworkStores<ScaffoldIdentityTestContext>();
            });
        }
    }
}