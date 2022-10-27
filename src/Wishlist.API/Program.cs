using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Wishlist.API.MappingProfiles;
using Wishlist.API.Middleware;
using Wishlist.Infrastructure;
using Wishlist.SharedKernel.Interfaces;

namespace Wishlist.API;

public static class Program
{
    public static async Task Main(string[] args)
        => await BuildWebApplication(args).RunAsync();

    private static WebApplication BuildWebApplication(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Logging.AddConsole();

        builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
        builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

        builder.Services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddHealthChecks();

        var env = builder.Environment.EnvironmentName;

        builder.Configuration.AddJsonFile("appsettings.json");
        builder.Configuration.AddJsonFile($"appsettings.{env}.json", optional: true);
        builder.Configuration.AddEnvironmentVariables();
        if (args.Any())
        {
            builder.Configuration.AddCommandLine(args);
        }

        var app = builder.Build();
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseDeveloperExceptionPage();
        }

        app.UseMiddleware<ExceptionMiddleware>();
        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.MapHealthChecks("/health", new HealthCheckOptions()
        {
            ResultStatusCodes = new Dictionary<HealthStatus, int>()
            {
                [HealthStatus.Healthy] = 200, [HealthStatus.Degraded] = 400, [HealthStatus.Unhealthy] = 500,
            },
        });
        app.MapControllers();

        return app;
    }
}