using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SofiaTeachersOnline.Database;
using SofiaTeachersOnline.Database.Models;

namespace SofiaTeachersOnline.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            /*            services.AddDbContext<ApplicationDbContext>(options =>
                            options.UseSqlServer(
                                Configuration.GetConnectionString("DefaultConnection")));*/

            /*            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                            .AddEntityFrameworkStores<ApplicationDbContext>();*/




            // Set database connection from application json file
            services.AddDbContext<SofiaTeachersOnlineDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));  // TODO: Fix name InitialCS

            // Add Identity
            // If this doesn't exit then "No service for type 'Microsoft.AspNetCore.Identity.UserManager' has been registered" error will appear
            services.AddIdentity<AppUser, AppRole>(options =>
            {
                //options.SignIn.RequireConfirmedAccount = true;    // TODO: Add later
                options.Password.RequireDigit = false;  // TODO: Modify to identity options
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            })
            .AddRoles<AppRole>()
            .AddEntityFrameworkStores<SofiaTeachersOnlineDbContext>();

            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            //app.UseAuthentication(); // TODO: What is it?
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
