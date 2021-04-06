using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PersonApi4.Controllers;
using PersonApi4.DataAccess;
using PersonApi4.Models;
using PersonApi4.Toolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonApi4.Services
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PersonApi4", Version = "v1" });
            });

            SetupMethods("ConfigureServices", services);
        }

        public void SetupMethods(string methodName, object anyObject)
        {
            var setupMethods = from assemblies in AppDomain.CurrentDomain.GetAssemblies()
                               from instanceTypes in assemblies.GetTypes()
                               from methods in instanceTypes.GetMethods()
                               where methods.Name == methodName
                               select methods;

            foreach (var currentMethod in setupMethods)
            {
                try
                {
                    currentMethod.Invoke(currentMethod.GetType(), new object[] { anyObject });
                }
                catch
                {
                    //throw new Exception("The method name is incorrect when it tries load by reflection");
                }
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PersonApi4 v1"));
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
