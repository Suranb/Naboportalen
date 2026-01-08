using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Naboportalen.Domain.Models;

namespace Naboportalen.Infrastructure.Persistence.Configurations;

public class NeighborhoodConfigurations : IEntityTypeConfiguration<Neighborhood>
{
    public void Configure(EntityTypeBuilder<Neighborhood> builder)
    {
        builder.ToTable("neighborhoods");

        builder.HasKey(n => n.Id);
        builder.Property(n => n.Name).IsRequired().HasMaxLength(100);
        builder.Property(n => n.Description).HasMaxLength(10000);
    }
}
