using IMD.Core.Models;

namespace IMD.Core.Persistence;

public interface IMeasurementRepository
{
    Task InitializeAsync(CancellationToken token);
    Task AddAsync(MeasurementDbRecord record, CancellationToken token);
}
