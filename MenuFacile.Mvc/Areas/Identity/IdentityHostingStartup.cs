using System;
using MenuFacile.Mvc.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(MenuFacile.Mvc.Areas.Identity.IdentityHostingStartup))]
namespace MenuFacile.Mvc.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<MenuFacileMvcContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("MenuFacileMvcContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<MenuFacileMvcContext>();
            });
        }
    }
}