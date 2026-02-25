using IMD.Core.Models;
using IMD.Core.Persistence;
using IMD.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace IMD.Infrastructure.Repositories;

public sealed class EfMeasurementRepository : IMeasurementRepository
{
    private readonly string _dbPath;

    public EfMeasurementRepository(string dbPath)
    {
        _dbPath = dbPath;
    }

    private MeasurementDbContext CreateContext()
    {
        var options = new DbContextOptionsBuilder<MeasurementDbContext>()
            .UseSqlite($"Data Source={_dbPath}")
            .Options;

        return new MeasurementDbContext(options);
    }

    public async Task InitializeAsync(CancellationToken token)
    {
        await using var db = CreateContext();
        await db.Database.EnsureCreatedAsync(token);
    }

    public async Task AddAsync(MeasurementDbRecord record, CancellationToken token)
    {
        await using var db = CreateContext();

        db.Measurements.Add(new MeasurementEntity
        {
            Timestamp = record.Timestamp,
            RawWidth = record.RawWidth,
            RawWeight = record.RawWeight,
            WidthMm = record.WidthMm,
            WeightG = record.WeightG,
            Status = record.Status,
            Ok = record.Ok,
            Note = record.Note
        });

        await db.SaveChangesAsync(token);
    }
}
