using Microsoft.EntityFrameworkCore;
using Naboportalen.Domain.Models;

namespace Naboportalen.Infrastructure.Persistence;

public class NaboportalenDbContext : DbContext
{
    public NaboportalenDbContext(DbContextOptions<NaboportalenDbContext> options) : base(options) { }

    public DbSet<Neighborhood> Neighborhoods { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(NaboportalenDbContext).Assembly);
    }
}
