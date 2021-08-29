using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SofiaTeachersOnline.Database;
using SofiaTeachersOnline.Database.Models;

[assembly: HostingStartup(typeof(SofiaTeachersOnline.Web.Areas.Identity.IdentityHostingStartup))]
namespace SofiaTeachersOnline.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}