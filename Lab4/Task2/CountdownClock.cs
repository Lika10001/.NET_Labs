namespace Task2;

public sealed class CountdownClock
{
    public event EventHandler<CountdownEventArgs>? CountdownFinished;

    public void StartCountdown(TimeSpan duration)
    {
        Thread.Sleep(duration);
        OnCountdownFinished(new CountdownEventArgs(duration));
    }

    private void OnCountdownFinished(CountdownEventArgs e)
    {
        CountdownFinished?.Invoke(this, e);
    }
}

public class CountdownEventArgs : EventArgs
{
    public TimeSpan Duration { get; }

    public CountdownEventArgs(TimeSpan duration)
    {
        Duration = duration;
    }
}