using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;

namespace DbInfoUpdater
{
    public class Program
    {
        public static void Main(string[] args)
        {

            //Serilog
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .WriteTo.File(@"C:\temp\DbInfoUpdater\LogFileUpdater.txt")
                .CreateLogger();

            try
            {
                Log.Information("Starter Worker service");
                CreateHostBuilder(args).Build().Run();

            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Problem med å starte Worker service");
                return;
            }
            finally
            {
                Log.CloseAndFlush();
            }

        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                   .UseWindowsService()
                   .ConfigureServices((hostContext, services) =>
                   {

                       services.AddHostedService<Worker>();
                   })
                   .UseSerilog();
        }

    }
}
