using System.Collections.Generic;
using Ardalis.ListStartupServices;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Wishlist.API.DIExtensions;
using Wishlist.API.MappingProfiles;
using Wishlist.API.Middleware;
using Wishlist.Infrastructure;
using Wishlist.SharedKernel.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.AddConsole();

builder.Services.AddHttpLogging(options => {
    options.LoggingFields = HttpLoggingFields.RequestPath |
                            HttpLoggingFields.RequestBody |
                            HttpLoggingFields.ResponseStatusCode |
                            HttpLoggingFields.ResponseBody;
    options.RequestBodyLogLimit = 8192;
    options.ResponseBodyLogLimit = 8192;
});

builder.Services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

builder.Services.AddMediatR(typeof(Wishlist.Core.Entities.WishlistAggregate.Wishlist).Assembly);
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();
// builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddHealthChecks();
builder.Services.Configure<ServiceConfig>(config =>
{
    config.Services = new List<ServiceDescriptor>(builder.Services);
    config.Path = "/allservices";
});

var env = builder.Environment.EnvironmentName;
builder.Configuration.AddEnvironmentVariables();
builder.Configuration.AddJsonFile("appsettings.json");
builder.Configuration.AddJsonFile($"appsettings.{env}.json", optional: true);


var app = builder.Build();
app.UseCustomHealthChecks();

if (app.Environment.IsDevelopment() || app.Environment.EnvironmentName == "Docker")
{
    app.Logger.LogInformation("Adding Development middleware...");
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseShowAllServicesMiddleware();
    app.UseDeveloperExceptionPage();
}
else
{
    app.Logger.LogInformation("Adding non-Development middleware...");
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpLogging();
app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Logger.LogInformation("LAUNCHING");
app.Run();
