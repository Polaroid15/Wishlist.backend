using Dapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WL.Application.Common.Interfaces;
using WL.Infrastructure.Identity;
using WL.Infrastructure.Persistence;
using WL.Infrastructure.Persistence.Repositories;
using WL.Infrastructure.Services;
using WL.Infrastructure.Settings;

namespace WL.Infrastructure;

public static class ConfigureServices
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        DefaultTypeMap.MatchNamesWithUnderscores = true;
        SqlMapper.AddTypeHandler(JObjectHandler.Instance);

        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("WishesDb")));
        if (configuration.GetValue<bool>("UseInMemoryDatabase"))
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseInMemoryDatabase("wishes_db"));
        }
        else
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("wishes_db")));
        }

        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<AppDbContext>());

        services
            .AddDefaultIdentity<ApplicationUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>();

        services.AddIdentityServer()
            .AddApiAuthorization<ApplicationUser, AppDbContext>();

        services.AddScoped<IApplicationDbContext, AppDbContext>();
        
        services.AddTransient<IIdentityService, IdentityService>();
        services.AddTransient<IDateTimeService, DateTimeService>();
        services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepository<>));
        services.AddSingleton<IConnectionStringSettings, ConnectionStringSettings>();
        
        
        services.AddAuthentication()
            .AddIdentityServerJwt();

        services.AddAuthorization(options =>
            options.AddPolicy("CanPurge", policy => policy.RequireRole("Administrator")));


    }
}