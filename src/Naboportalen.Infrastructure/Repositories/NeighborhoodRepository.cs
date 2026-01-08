using Naboportalen.Application.Features.Neighborhoods;
using Naboportalen.Domain.Models;
using Naboportalen.Infrastructure.Persistence;

namespace Naboportalen.Infrastructure.Repository;

public class NeighborhoodRepository : INeighborhoodRepository
{
    private readonly NaboportalenDbContext _dbContext;
    public NeighborhoodRepository(NaboportalenDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CreateAsync(Neighborhood neighborhood, CancellationToken cancellationToken)
    {
        await _dbContext.Neighborhoods.AddAsync(neighborhood);
        await _dbContext.SaveChangesAsync();
    }
}