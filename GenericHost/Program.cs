using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.IO;

namespace GenericHost
{
    class Program
    {
        static void Main(string[] args) => CreateHostBuilder(args).Build().Run();

        public static IHostBuilder CreateHostBuilder(string[] args)
            => Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostContext, configApp) =>
            {
                configApp.SetBasePath(Directory.GetCurrentDirectory());
                configApp.AddJsonFile("appsettings.Json");
            })
            .ConfigureServices((hosContext, services) =>
            {
                services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(hosContext.Configuration.GetConnectionString("DefaultConnection")));
                services.AddHostedService<MainService>();
            })
            .UseSerilog(new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File("C:\\log\\log.txt")
                .CreateLogger());
    }
}
