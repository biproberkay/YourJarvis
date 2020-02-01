using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using YourJarvis.Infrastructure.Data.EfCore;

namespace YourJarvis.WebUI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<YourJarvisContext>();
            services.AddMvc(options => options.EnableEndpointRouting = false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "AreaRoute",
                template: "{area:exists}/{controller}/{action}/{id?}/{title?}",
                defaults: new { controller = "Merhaba", action = "Index" });

                routes.MapRoute(name:"defaut", 
                    template:"{controller=Home}/{action=Index}/{id?}");

            });
        }
    }
}
