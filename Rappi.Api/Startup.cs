using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Rappi.Core.Interfaces;
using Rappi.Core.Services;
using Rappi.Infrastructure.Data;
using Rappi.Infrastructure.Repositories;

namespace Rappi.Api
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
            //configuracion para integrar servicios con angular
            services.AddCors(options =>
            {
                
                options.AddPolicy(
                  "CorsPolicy",
                  builder => builder.WithOrigins("http://localhost:4200")
                  .AllowAnyMethod()
                  .AllowAnyHeader()
                  .AllowCredentials());
            });
            services.AddAuthentication(IISDefaults.AuthenticationScheme);

            //SuppressModelStateInvalidFilter nos ayuda a eliminar mensaje de response con data que no le interesa al  request
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            })
            .ConfigureApiBehaviorOptions(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            })
                ;

            services.AddControllers();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IEmployeeService, EmployeeService>();

            services.AddTransient<IAreaRepository, AreaRepository>();
            services.AddTransient<IAreaService, AreaService>();

            services.AddTransient<ITypeIdentificationRepository, TypeIdentificationRepository>();
            services.AddTransient<ITypeIdentificationService, TypeIdentificationService>();

            services.AddAuthentication(IISDefaults.AuthenticationScheme);

            //implementar llamado a la cadena de conexion que esta en appsettings.json
            services.AddDbContext<RAPPIContext>(Options =>
            Options.UseSqlServer(Configuration.GetConnectionString("RAPPI")));


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            //configuracion para integrar angular
            app.UseCors("CorsPolicy");
            //app.UsePreflightRequestHandler();

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
