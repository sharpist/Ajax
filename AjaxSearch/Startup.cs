using AjaxSearch.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AjaxSearch
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) =>
            Configuration = configuration;


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
                Configuration["Data:AjaxSearchBooks:ConnectionString"]));

            services.AddTransient<IBookRepository, EFBookRepository>();

            services.AddControllersWithViews(options =>
            {
                options.SuppressAsyncSuffixInActionNames = false;
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment() || env.IsStaging()) {
                app.UseDeveloperExceptionPage();
            }
            else {
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute(
                    name: "Default",
                    pattern: "{controller}/{action}/{id?}",
                    defaults: new {
                        controller = "Main",
                        action = "Search"
                    });
            });

            SeedData.EnsurePopulated(app);
        }
    }
}
