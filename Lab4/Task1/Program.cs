namespace Task1;

abstract class Program
{
    static void Main(string[] args)
    {
        try
        {
            using (LogBuffer logBuffer = new LogBuffer("log.txt", 10, TimeSpan.FromSeconds(5)))
            {
                for (int i = 1; i <= 20; i++)
                {
                    string message = $"Log message {i}";
                    logBuffer.Add(message);
                    Console.WriteLine($"Added message: {message}");
                    Thread.Sleep(250);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        Console.WriteLine("End of program.");
    }
}