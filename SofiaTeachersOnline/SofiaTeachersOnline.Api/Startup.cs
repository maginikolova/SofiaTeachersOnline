using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using SofiaTeachersOnline.Database;
using SofiaTeachersOnline.Database.Models;
using SofiaTeachersOnline.Services.DTOs;
using SofiaTeachersOnline.Services.Services;
using SofiaTeachersOnline.Services.Services.Contracts;

namespace SofiaTeachersOnline.Api
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
            services.AddControllers();

            // TODO: Move this in extension class?
            services.AddScoped<IEntityService<Course, CourseDTO>, CourseService>();
            //services.AddScoped<IEntityService<CourseProgress, CourseProgressDTO>, CourseProgressService>();
            services.AddScoped<IEntityService<Exercise, ExerciseDTO>, ExerciseService>();
            services.AddScoped<IEntityService<Grade, GradeDTO>, GradeService>();
            services.AddScoped<IWannaBeUserService, WannaBeUserService>();


            // NOTE: This is for the UserManager  TODO: Fix the modifiedBy
            //services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            // Or you can also register as follows
            //services.AddHttpContextAccessor();


            services.AddDbContext<SofiaTeachersOnlineDbContext>
                (options => options.UseSqlServer(Configuration.GetConnectionString("InitialCS")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
