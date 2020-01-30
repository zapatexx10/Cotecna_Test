using Cotecna.Inspections.Abstractions.Bootstrap;
using Cotecna.Inspections.Abstractions.Entities;
using Cotecna.Inspections.Core.Bootstrap;
using Cotecna.Inspections.Infrastructure.Bootstrap;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Cotecna.Inspections.WebAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddMvc(option => option.EnableEndpointRouting = false);

            services.AddSwaggerGen(opts => opts.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Cotecna inspections information", Version = "v1" }));

            services.AddSingleton<IDictionary<int, Inspection>>(new Dictionary<int, Inspection>());

            RegisterPartial<InfrastructureStartup>(services);
            RegisterPartial<CoreStartup>(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(opts => opts.SwaggerEndpoint("/swagger/v1/swagger.json", "Contact v1"));
        }

        public void RegisterPartial<T>(IServiceCollection services)
           where T : IPartialStartup, new()
        {
            T partialStartup = new T();

            partialStartup.RegisterConfiguration(services, Configuration);
            partialStartup.RegisterServices(services);
        }
    }
}
