
namespace ParallelWaitAll;

abstract class Program
{
    static void Main(string[] args)
    {
        Action[] actions =
        {
            () => Task1(),
            () => Task2(),
            () => Task3()
        };

        Console.WriteLine("Starting parallel execution...");

        DateTime startTime = DateTime.Now;
        ParallelWaitAllClass.ParallelWaitAll(actions);
        DateTime endTime = DateTime.Now;

        TimeSpan executionTime = endTime - startTime;
        Console.WriteLine($"Parallel execution completed in {executionTime.TotalSeconds} seconds.");
    }

    static void Task1()
    {
        Console.WriteLine("Task 1 started.");
        Thread.Sleep(2000);
        Console.WriteLine("Task 1 completed.");
    }

    static void Task2()
    {
        Console.WriteLine("Task 2 started.");
        Thread.Sleep(3000);
        Console.WriteLine("Task 2 completed.");
    }

    static void Task3()
    {
        Console.WriteLine("Task 3 started.");
        Thread.Sleep(1500);
        Console.WriteLine("Task 3 completed.");
    }
}
