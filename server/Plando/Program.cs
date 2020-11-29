using System;
using System.Collections.Generic;
using Convey;
using Convey.Auth;
using Convey.CQRS.Commands;
using Convey.CQRS.Events;
using Convey.CQRS.Queries;
using Convey.Docs.Swagger;
using Convey.WebApi;
using Convey.WebApi.CQRS;
using Convey.WebApi.Swagger;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Plando.Commands.Users;
using Plando.DTOs;
using Plando.Models;
using Plando.Queries.Users;
using Plando.Router;

namespace Plando
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var host = GetWebHostBuilder(args).Build();

            CreateDbIfNotExists(host);

            host.Run();
        }

        public static IWebHostBuilder GetWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    services
                        .AddDatabase(context.Configuration)
                        .AddConvey()
                        .AddCQRS()
                        .AddWebApi()
                        .AddSwaggerDocs()
                        .AddWebApiSwaggerDocs()
                        .Build();
                })
                .Configure(app => app
                    .UseRoutes()
                    .UseSwaggerDocs());
        }

        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetSection("db")["connectionString"];

            return services.AddDbContext<ApplicationContext>(
                options => options.UseSqlite(connectionString));
        }

        private static void CreateDbIfNotExists(IWebHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<ApplicationContext>();
                    ApplicationContextSeed.Initialize(context);
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }
        }

        public static IApplicationBuilder UseRoutes(this IApplicationBuilder app) =>
            app.UseDispatcherEndpoints(endpoints => endpoints
                .AddUserRouter()
                .AddOrdersRouter()
                .AddServicesRouter()
                .AddLaundriesRouter());

        public static IConveyBuilder AddCQRS(this IConveyBuilder builder) =>
            builder.AddCommandHandlers()
                .AddQueryHandlers()
                .AddEventHandlers()
                .AddInMemoryCommandDispatcher()
                .AddInMemoryQueryDispatcher()
                .AddInMemoryEventDispatcher();
    }
}
