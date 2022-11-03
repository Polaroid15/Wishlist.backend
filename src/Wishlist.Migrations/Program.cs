using System;
using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

const string ENVIRONMENT_VARIABLE_NAME = "ASPNETCORE_ENVIRONMENT";
const string DATABASE_NAME = "Wishlist";

var serviceProvider = CreateServices();

using var scope = serviceProvider.CreateScope();
var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
runner.MigrateUp();


static IServiceProvider CreateServices()
{
    var env = Environment.GetEnvironmentVariable(ENVIRONMENT_VARIABLE_NAME);
    var config = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .AddJsonFile($"connectrionStrings/{env}.json")
        .AddEnvironmentVariables()
        .Build();

    return new ServiceCollection()
        .AddSingleton<IConfiguration>(config)
        .AddFluentMigratorCore()
        .ConfigureRunner(rb => rb
            .AddPostgres11_0()
            .WithGlobalConnectionString(x => x.GetRequiredService<IConfiguration>().GetConnectionString(DATABASE_NAME))
            .WithGlobalCommandTimeout(TimeSpan.FromMinutes(5))
            .ScanIn(typeof(Program).Assembly).For.Migrations())
        .AddLogging(lb => lb.AddFluentMigratorConsole())
        .BuildServiceProvider(false);
}