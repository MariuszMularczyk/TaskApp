using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Autofac;
using TaskApp.EntityFramework;
using TaskApp.Application;
using TaskApp.Data;
using System.Reflection;
using Autofac.Extensions.DependencyInjection;
using TaskApp.Infrastructure;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Http.Connections;
using Autofac.Extras.DynamicProxy;
using Microsoft.OpenApi.Models;

namespace TaskApp.WebAPI
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            this.Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; private set; }

        public ILifetimeScope AutofacContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            
            //services.AddDbContext<MainDatabaseContext>(o => o.UseSqlServer(Configuration.GetConnectionString("MainDatabaseContext")));
            services.AddDbContext<MainDatabaseContext>(opt => opt.UseInMemoryDatabase(databaseName: "TaskApp"));

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.WithOrigins("http://localhost:8080")
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                       .AllowCredentials();
            }));

            services.AddControllers().AddNewtonsoftJson();
            services.AddSwaggerGen();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = " Swagger UI",
                    Description = "Swagger UI",
                });
            });

        }
        public void ConfigureContainer(ContainerBuilder builder)
        {
            // This will all go in the ROOT CONTAINER and is NOT TENANT SPECIFIC.IDrinkRepository

            builder.RegisterType<MainContext>().AsSelf().PropertiesAutowired().InstancePerLifetimeScope();
            builder.RegisterType<TransactionInterceptor>().AsSelf().PropertiesAutowired().InstancePerLifetimeScope();
            builder.RegisterType<DbSession>().AsSelf().PropertiesAutowired().InstancePerLifetimeScope();

            builder.Register(context => MainDatabaseContext.Create()).As<MainDatabaseContext>().PropertiesAutowired().InstancePerLifetimeScope();
            builder.RegisterType<TransactionInterceptor>().InstancePerLifetimeScope();


            builder.RegisterType<TripService>().As<ITripService>().PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies).InstancePerLifetimeScope();
            builder.RegisterType<TripService>().As<TripService>().PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies).InstancePerLifetimeScope();
            builder.RegisterType<TripRepository>().As<ITripRepository>().PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies).InstancePerLifetimeScope();
            builder.RegisterType<TripRepository>().As<TripRepository>().PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies).InstancePerLifetimeScope();
            builder.RegisterType<TripConverter>().As<TripConverter>().PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies).InstancePerLifetimeScope();

            builder.RegisterType<MailRepository>().As<IMailRepository>().PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies).InstancePerLifetimeScope();
            builder.RegisterType<MailRepository>().As<MailRepository>().PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies).InstancePerLifetimeScope();

            builder.RegisterType<AppSettingsRepository>().As<IAppSettingsRepository>().PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies).InstancePerLifetimeScope();
            builder.RegisterType<AppSettingsRepository>().As<AppSettingsRepository>().PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies).InstancePerLifetimeScope(); 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, MainDatabaseContext db)
        {


                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Showing API V1");
                });
            


            app.UseRouting();

            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseCors("MyPolicy");

            //db.Database.Migrate();
            db.Database.EnsureCreated();

            app.UseHttpsRedirection();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
