using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using PruebaIngresoBibliotecario.Api.Filters;
using PruebaIngresoBibliotecario.Infrastructure.Extensions;
using System;
using System.Diagnostics;
using System.Reflection;

namespace PruebaIngresoBibliotecario.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
            Trace.AutoFlush = true;
            Trace.Indent();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers(options => options.Filters.Add(typeof(AppExceptionFilterAttribute)))
            .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                };
            });

            services.AddMediatR(Assembly.Load("PruebaIngresoBibliotecario.Application"), typeof(Program).Assembly);

            Assembly[] assemblies = new Assembly[] { Assembly.Load("PruebaIngresoBibliotecario.Application") };
            services.AddAutoMapper(assemblies);

            services.AddSwaggerDocument();
            services.AddDomainServices();
            services.AddRepositories();
            services.AddDependencies();

        }


        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseOpenApi();
            app.UseSwaggerUi3();
            app.AddModelSeedExtensions();

        }
    }
}
