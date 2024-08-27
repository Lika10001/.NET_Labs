namespace TaskQueue;

abstract class Program
{
    static void Main(string[] args)
    {
        TaskQueue taskQueue = new TaskQueue(10);

        TaskQueue.TaskDelegate task1 = () => {
            Console.WriteLine("Task 1 executed");
        };

        TaskQueue.TaskDelegate task2 = () => {
            Console.WriteLine("Task 2 executed");
        };
        
        TaskQueue.TaskDelegate task3 = () => {
            Console.WriteLine("Task 3 executed");
        };
        
        TaskQueue.TaskDelegate task4 = () => {
            Console.WriteLine("Task 4 executed");
        };

        TaskQueue.TaskDelegate task5 = () => {
            Console.WriteLine("Task 5 executed");
        };
        
        TaskQueue.TaskDelegate task6 = () => {
            Console.WriteLine("Task 6 executed");
        };
        
        TaskQueue.TaskDelegate task7 = () => {
            Console.WriteLine("Task 7 executed");
        };

        TaskQueue.TaskDelegate task8 = () => {
            Console.WriteLine("Task 8 executed");
        };
        
        TaskQueue.TaskDelegate task9 = () => {
            Console.WriteLine("Task 9 executed");
        };
        TaskQueue.TaskDelegate task10 = () => {
            Console.WriteLine("Task 10 executed");
        };

        taskQueue.EnqueueTask(task1);
        taskQueue.EnqueueTask(task2);
        taskQueue.EnqueueTask(task3);
        taskQueue.EnqueueTask(task4);
        taskQueue.EnqueueTask(task5);
        taskQueue.EnqueueTask(task6);
        taskQueue.EnqueueTask(task7);
        taskQueue.EnqueueTask(task8);
        taskQueue.EnqueueTask(task9);
        taskQueue.EnqueueTask(task10);
        
        taskQueue.Stop();

        while (!taskQueue.AllThreadsCompleted)
        {
            Thread.Sleep(10);
        }
    }
}