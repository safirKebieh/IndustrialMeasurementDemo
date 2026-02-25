using Microsoft.EntityFrameworkCore;

namespace IMD.Infrastructure.Persistence;

public sealed class MeasurementDbContext : DbContext
{
    public DbSet<MeasurementEntity> Measurements => Set<MeasurementEntity>();

    public MeasurementDbContext(DbContextOptions<MeasurementDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MeasurementEntity>()
            .HasIndex(x => x.Timestamp);
    }
}
