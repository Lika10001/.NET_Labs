namespace Task1;

abstract class Program
{
    private static Mutex? _mutex;

    private static Thread[]? _threads;
    
    static void Main(string[] args)
    {
        int threadNumber = 10;
        int count = 0;
        _mutex = new Mutex();
        
        _threads = new Thread[threadNumber];

        for (int i = 0; i < threadNumber; i++)
        {
            int number = i;
            Thread thread = new Thread(() =>
            {
                Console.WriteLine($"Thread id {number + 1}");
                Thread.Sleep(10);
                _mutex.Lock();
                count++;
                Thread.Sleep(10);
                if (count != 1)
                {
                    throw new Exception("Mutex doesn't work.");
                }
                Thread.Sleep(10);
                count--;
                if (count != 0)
                {
                    throw new Exception("Mutex doesn't work.");
                }
                _mutex.Unlock();
            })
            
            {
                IsBackground = true
            };
            
            _threads[i] = thread;
            thread.Start();
        }
        Console.ReadLine();
    }
}