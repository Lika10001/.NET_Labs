namespace Task2
{
    abstract class Program
    {
        static void Main()
        {
            CountdownClock clock = new CountdownClock();
            clock.CountdownFinished += Clock_CountdownFinished;
            
            clock.CountdownFinished += AnotherClass.AnotherEventHandler;
            clock.CountdownFinished += SomeClass.SomeEventHandler;
            clock.CountdownFinished += AnotherType.AnotherTypeEventHandler;

            TimeSpan duration = TimeSpan.FromSeconds(5);
            Console.WriteLine("Countdown started. Waiting for it to finish...");
            clock.StartCountdown(duration);
            Console.ReadLine();
        }

        static void Clock_CountdownFinished(object sender, CountdownEventArgs e)
        {
            Console.WriteLine($"Countdown finished! Duration: {e.Duration}");
        }
    }

    public abstract class AnotherClass
    {
        public static void AnotherEventHandler(object sender, CountdownEventArgs e)
        {
            Console.WriteLine($"AnotherClass received countdown finished event. Duration: {e.Duration}");
        }
    }

    public abstract class SomeClass
    {
        public static void SomeEventHandler(object sender, CountdownEventArgs e)
        {
            Console.WriteLine($"SomeClass received countdown finished event. Duration: {e.Duration}");
        }
    }

    public abstract class AnotherType
    {
        public static void AnotherTypeEventHandler(object sender, CountdownEventArgs e)
        {
            Console.WriteLine($"AnotherType received countdown finished event. Duration: {e.Duration}");
        }
    }
}