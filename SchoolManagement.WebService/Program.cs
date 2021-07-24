using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.WebService
{
    public class Program
    {
        public static int Main(string[] args)
        {
            var configurationBuilder = new ConfigurationBuilder().AddEnvironmentVariables().Build();

            try
            {
                var host = CreateHostBuilder(configurationBuilder, args);
                host.Run();

                return 0;
            }
            catch (Exception ex)
            {
                return 1;
            }
            finally
            {
                //Log.CloseAndFlush();
            }
        }

        private static IWebHost CreateHostBuilder(IConfiguration configuration, string[] args) =>
            WebHost.CreateDefaultBuilder(args)

            .UseStartup<Startup>()
            .UseContentRoot(Directory.GetCurrentDirectory())
            .ConfigureAppConfiguration((builderContext, config) =>
            {
                config.AddConfiguration(configuration);
            }).Build();
    }
}
