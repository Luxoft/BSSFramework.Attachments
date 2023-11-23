using System;
using System.IO;

using Framework.WebApi.Utils;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

using Serilog;

namespace AttachmentsSampleSystem.WebApiCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = Configuration.CreateLoggerBss();

            try
            {
                CreateWebHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateWebHostBuilder(string[] args) =>
                Host.CreateDefaultBuilder(args)
                    .UseSerilogBss()
                    .UseDefaultServiceProvider(
                                               o =>
                                               {
                                                   o.ValidateScopes = true;
                                                   o.ValidateOnBuild = true;
                                               })
                    .ConfigureWebHostDefaults(
                                              webBuilder =>
                                              {
                                                  webBuilder.UseStartup<Startup>()
                                                            .UseConfiguration(Configuration);
                                              });

        private static IConfiguration Configuration =>
            new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .AddEnvironmentVariables()
            .Build();
    }
}
