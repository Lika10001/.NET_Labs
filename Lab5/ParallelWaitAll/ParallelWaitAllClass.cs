namespace ParallelWaitAll;

public static class ParallelWaitAllClass
{
    
    public static void ParallelWaitAll(Action[] actions)
    {
        Task[] tasks = new Task[actions.Length];

        for (int i = 0; i < actions.Length; i++)
        {
            tasks[i] = Task.Run(actions[i]);
        }

        Task.WaitAll(tasks);
    }
    
}