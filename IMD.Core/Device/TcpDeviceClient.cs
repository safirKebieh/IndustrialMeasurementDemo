using System.Net.Sockets;
using System.Text;

namespace IMD.Core.Device
{
    public sealed class TcpDeviceClient : IDeviceClient
    {
        private TcpClient? _client;
        private StreamReader? _reader;

        public async Task ConnectAsync(string host, int port, CancellationToken token)
        {
            _client = new TcpClient();
            await _client.ConnectAsync(host, port, token);

            var stream = _client.GetStream();
            _reader = new StreamReader(stream, Encoding.ASCII);
        }

        public async IAsyncEnumerable<string> ReadLinesAsync(
            [System.Runtime.CompilerServices.EnumeratorCancellation] CancellationToken token)
        {
            if (_reader is null)
                throw new InvalidOperationException("Not connected.");

            while (!token.IsCancellationRequested && _client?.Connected == true)
            {
                var line = await _reader.ReadLineAsync(token);

                if (line is null)
                    yield break;

                yield return line;
            }
        }

        public ValueTask DisposeAsync()
        {
            _reader?.Dispose();
            _client?.Dispose();
            return ValueTask.CompletedTask;
        }
    }
}
