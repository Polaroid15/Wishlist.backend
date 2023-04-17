using System.Reflection;
using Ardalis.ListStartupServices;
using Wishlist.Application;
using Wishlist.Application.Common.Interfaces;
using Wishlist.Infrastructure;
using Wishlist.PublicApi.DiExtensions;
using Wishlist.PublicApi.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.AddConsole();

builder.Services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

var env = builder.Environment.EnvironmentName;
builder.Configuration.AddEnvironmentVariables();
builder.Configuration.AddJsonFile("appsettings.json");
builder.Configuration.AddJsonFile($"appsettings.{env}.json", optional: true);

builder.Services.AddControllers();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options => {
    options.DescribeAllParametersInCamelCase();
    var xmlFileName = Assembly.GetExecutingAssembly().GetName().Name + ".xml";
    var xmlFilePath = Path.Combine(AppContext.BaseDirectory, xmlFileName);
    options.IncludeXmlComments(xmlFilePath);
});

builder.Services.AddHealthChecks();
builder.Services.Configure<ServiceConfig>(config =>
{
    config.Services = new List<ServiceDescriptor>(builder.Services);
    config.Path = "/allservices";
});

var app = builder.Build();
app.UseCustomHealthChecks();

if (app.Environment.IsDevelopment() || app.Environment.EnvironmentName == "Docker")
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseShowAllServicesMiddleware();
    app.UseDeveloperExceptionPage();
}
else
{
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
