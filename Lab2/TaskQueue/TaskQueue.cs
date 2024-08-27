namespace TaskQueue;

public class TaskQueue
{
    private readonly Queue<TaskDelegate> _taskQueue;
    private readonly object _queueLock;
    private readonly List<Thread> _threads;
    private bool _isStopped;
    private int _threadsCompleted;

    public delegate void TaskDelegate();

    public TaskQueue(int threadCount)
    {
        _taskQueue = new Queue<TaskDelegate>();
        _queueLock = new object();
        _threads = new List<Thread>();
        _isStopped = false;
        _threadsCompleted = 0;
        
        for (int i = 0; i < threadCount; i++)
        {
            Thread thread = new Thread(WorkerThread);
            _threads.Add(thread);
            thread.Start();
        }
    }

    public void EnqueueTask(TaskDelegate task)
    {
        lock (_queueLock)
        {
            if (_isStopped)
            {
                throw new InvalidOperationException("TaskQueue has been stopped. No new tasks can be enqueued.");
            }
            _taskQueue.Enqueue(task);
            Monitor.Pulse(_queueLock);
        }
    }

    public void Stop()
    {
        lock (_queueLock)
        {
            _isStopped = true;
            Monitor.PulseAll(_queueLock);
        }

        foreach (Thread thread in _threads)
        {
            thread.Join();
        }
    }

    private void WorkerThread()
    {
        while (true)
        {
            TaskDelegate task;

            lock (_queueLock)
            {
                while (_taskQueue.Count == 0 && !_isStopped)
                {
                    Monitor.Wait(_queueLock);
                }

                if (_isStopped && _taskQueue.Count == 0)
                {
                    Interlocked.Increment(ref _threadsCompleted);
                    return;
                }
                task = _taskQueue.Dequeue();
                int threadId = Thread.CurrentThread.ManagedThreadId;
                Console.WriteLine($"Thread {threadId} executing task.");
            }
            try
            {
                task.Invoke();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An exception occurred while executing a task: {ex}");
            }
        }
    }
    
    public bool AllThreadsCompleted => _threadsCompleted == _threads.Count;
}