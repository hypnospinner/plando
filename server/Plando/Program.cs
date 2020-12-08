using System;
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
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Plando.Models;
using Plando.Router;

namespace Plando
{
    public static class Program
    {
        private const string PROD = "production";
        private class DBConfig
        {
            public string Server { get; set; }
            public string Database { get; set; }
            public string User { get; set; }
            public string Password { get; set; }
            public string ConnectionString => $"Server={Server};Database={Database};User={User};Password={Password};";
        }
        public static void Main(string[] args)
        {
            var host = GetWebHostBuilder(args).Build();

            CreateDbIfNotExists(host);

            host.Run();
        }

        public static IWebHostBuilder GetWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) => services
                    .AddDatabase(context.Configuration)
                    .AddGoogleAuthentication()
                    .AddConvey()
                    .AddCQRS()
                    .AddWebApi()
                    .AddSwaggerDocs()
                    .AddWebApiSwaggerDocs()
                    .Build())
                .Configure(app => app
                    .UseAuthentication()
                    .UseAuthorization()
                    .UseConvey()
                    .UseRoutes()
                    .UseSwaggerDocs());
        }

        private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var env = (Environment.GetEnvironmentVariable("ENVIRONMENT"));

            if (env is PROD)
            {
                var dbConfig = new DBConfig();
                configuration.Bind("mssqldb", dbConfig);

                return services.AddDbContext<ApplicationContext>(
                    options => options.UseSqlServer(dbConfig.ConnectionString));
            }
            else
            {
                var connectionString = configuration.GetSection("db")["connectionString"];

                return services.AddDbContext<ApplicationContext>(
                    options => options.UseSqlite(connectionString));
            }
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

        private static IApplicationBuilder UseRoutes(this IApplicationBuilder app) =>
            app.UseDispatcherEndpoints(endpoints => endpoints
                .AddUserRouter()
                .AddOrdersRouter()
                .AddServicesRouter()
                .AddLaundriesRouter()
                .AddAuthRouter());

        private static IConveyBuilder AddCQRS(this IConveyBuilder builder) =>
            builder.AddCommandHandlers()
                .AddQueryHandlers()
                .AddEventHandlers()
                .AddInMemoryCommandDispatcher()
                .AddInMemoryQueryDispatcher()
                .AddInMemoryEventDispatcher();

        private static IServiceCollection AddGoogleAuthentication(this IServiceCollection services)
        {
            services
                .AddAuthentication(options =>
                    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                    options.LoginPath = "/account/google-login")
                .AddGoogle(options =>
                    (options.ClientId,
                    options.ClientSecret) =
                    ("426075564145-b2g0u99p7utdgsjril2qa8vd6sk0u2hj.apps.googleusercontent.com",
                    "s127voGZoRqZ3PGl_7Xa1pL6"));

            return services;
        }
    }
}
