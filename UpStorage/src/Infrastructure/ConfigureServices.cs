using Infrastructure.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)//(extend,parameter)
    {
        
        var connectionString = configuration.GetConnectionString("MariaDB")!;

        //DbContext
        services.AddDbContext<ApplicationDbContext>(opt => opt
            .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
       
        services.AddScoped<ApplicationDbContext>(provider => provider
            .GetRequiredService<ApplicationDbContext>());

        return services;
    }
}