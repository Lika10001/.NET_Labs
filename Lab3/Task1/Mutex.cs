namespace Task1;
using System.Threading;

public class Mutex
{
    private const int Locked = 1;
    private const int Unlocked = 0;

    private int _state = Unlocked;

    public void Lock()
    {
        while (true)
        {
            int previousState = Interlocked.CompareExchange(ref _state, Locked, Unlocked);

            if (previousState == Unlocked)
            {
                return;
            }
            Thread.Sleep(10);
        }
    }

    public void Unlock()
    {
        Interlocked.Exchange(ref _state, Unlocked);
    }
}