namespace IMD.Core.Device
{
    public interface IDeviceClient : IAsyncDisposable
    {
        Task ConnectAsync(string host, int port, CancellationToken token);

        IAsyncEnumerable<string> ReadLinesAsync(CancellationToken token);
    }
}
