using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Naboportalen.Application.Features.Neighborhoods;
using Naboportalen.Infrastructure.Persistence;
using Naboportalen.Infrastructure.Repository;

namespace Contactum.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<NaboportalenDbContext>(options =>
            options.UseNpgsql(
                configuration.GetConnectionString("DefaultConnection"),
                x => x.MigrationsAssembly(typeof(NaboportalenDbContext).Assembly.FullName)
            ));


        services.AddScoped<INeighborhoodRepository, NeighborhoodRepository>();
        return services;
    }
}
