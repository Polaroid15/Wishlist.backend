using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Wishlist.API;

public static class Program
{
    public static async Task Main(string[] args)
        => await CreateBuilder(args).Build().RunAsync();

    private static IHostBuilder CreateBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((context, configBuilder) =>
            {
                var env = context.HostingEnvironment.EnvironmentName;

                configBuilder.AddJsonFile("appsettings.json");
                configBuilder.AddJsonFile($"appsettings.{env}.json", optional: true);

                configBuilder.AddEnvironmentVariables();
                if (args.Any())
                {
                    configBuilder.AddCommandLine(args);
                }
            })
            .ConfigureWebHostDefaults(builder =>
            {
                builder
                    .UseStartup<Startup>();
            });
}