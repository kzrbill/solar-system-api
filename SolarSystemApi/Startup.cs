using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SolarSystemApi.Services;
using Swashbuckle.AspNetCore.Swagger;

namespace SolarSystemApi
{
    public class Startup
    {
        private const string APIVersion = "v0.1.0";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddTransient<IServiceFactory, ServiceFactory>();

            DBInitializer.Init(new ServiceFactory().CreateDB());

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(APIVersion, new Info { Title = "Solar System API", Version = APIVersion });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // TODO: Restrict headers/create proxy
            app.UseCors(builder => builder.WithOrigins("http://solarsystemui.azurewebsites.net")
                        .AllowAnyHeader());

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/{APIVersion}/swagger.json", $"Solars System API {APIVersion}");
            });

            var options = new RewriteOptions().AddRedirect("$^", "/swagger");
            app.UseRewriter(options);

            app.UseMvc();
        }
    }
}
