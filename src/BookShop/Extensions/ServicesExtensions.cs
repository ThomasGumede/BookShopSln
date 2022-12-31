using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Data.Interfaces;
using Data.Repository;
using Service.Interfaces;
using Data.Identity;
using Data;
using Service;

namespace BookShop.Extensions;

public static class ServicesExtensions
{
    public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
        services.AddDbContext<RepositoryContext>(opts =>
            opts.UseNpgsql(configuration.GetConnectionString("PostgreSqlConnection"),
                b => b.MigrationsAssembly("BookShop")));

    public static void ConfigureLoggerService(this IServiceCollection services) =>
        services.AddSingleton<ILoggerManager, LoggerManager>();

    public static void ConfigureRepositoryManager(this IServiceCollection services) =>
        services.AddScoped<IRepositoryManager, RepositoryManager>();

    public static void ConfigureServiceManager(this IServiceCollection services) =>
        services.AddScoped<IServiceManager, ServiceManager>();

    public static void ConfigureIdentity(this IServiceCollection services)
    {
        var builder = services.AddIdentity<User, IdentityRole>(o =>
        {
            o.Password.RequireDigit = true;
            o.Password.RequireLowercase = false;
            o.Password.RequireUppercase = false;
            o.Password.RequireNonAlphanumeric = false;
            o.Password.RequiredLength = 8;
            o.User.RequireUniqueEmail = true;
        })
        .AddEntityFrameworkStores<RepositoryContext>()
        .AddDefaultTokenProviders();
    }
}
