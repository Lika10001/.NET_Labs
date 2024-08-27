namespace Task1;

public class LogBuffer : IDisposable
{
    private readonly string _filePath;
    private readonly int _bufferSize;
    private readonly TimeSpan _flushInterval;

    private readonly List<string> _buffer;
    private readonly object _bufferLock;

    private readonly CancellationTokenSource _cancellationTokenSource;
    private readonly Task _flushTask;

    public LogBuffer(string filePath, int bufferSize, TimeSpan flushInterval)
    {
        _filePath = filePath;
        _bufferSize = bufferSize;
        _flushInterval = flushInterval;

        _buffer = new List<string>(bufferSize);
        _bufferLock = new object();

        _cancellationTokenSource = new CancellationTokenSource();
        _flushTask = StartFlushTask();
    }

    public void Add(string message)
    {
        lock (_bufferLock)
        {
            _buffer.Add(message);

            if (_buffer.Count >= _bufferSize)
                FlushBuffer();
        }
    }

    private void FlushBuffer()
    {
        lock (_bufferLock)
        {
            if (_buffer.Count > 0)
            {
                WriteToFile(_buffer);
                _buffer.Clear();
            }
        }
    }

    private async Task StartFlushTask()
    {
        while (!_cancellationTokenSource.Token.IsCancellationRequested)
        {
            await Task.Delay(_flushInterval, _cancellationTokenSource.Token);
            FlushBuffer();
        }
    }

    private void WriteToFile(List<string> messages)
    {
        string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        string logEntry = $"{timestamp}: {string.Join(Environment.NewLine, messages)}";

        using StreamWriter writer = File.AppendText(_filePath);
        writer.WriteLine(logEntry);
    }

    public void Dispose()
    {
        _cancellationTokenSource.Cancel();
        try
        {
            _flushTask.Wait();
        }
        catch (TaskCanceledException ex)
        {
            Console.WriteLine("Error:" + ex.Message);
        }
        finally
        {
            _flushTask.Dispose();
            _cancellationTokenSource.Dispose();
        }
    }
}