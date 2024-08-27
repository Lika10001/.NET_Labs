namespace Task2._2;

abstract class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: Task2.2.exe [sourceDirectory] [targetDirectory]");
            return;
        }

        string sourceDirectory = args[0];
        string targetDirectory = args[1];

        if (!Directory.Exists(sourceDirectory))
        {
            Console.WriteLine("Source directory does not exist.");
            return;
        }

        if (!Directory.Exists(targetDirectory))
        {
            Console.WriteLine("Target directory does not exist.");
            return;
        }

        string[] files = Directory.GetFiles(sourceDirectory);

        int totalFiles = files.Length;
        int copiedFiles = 0;
        object lockObject = new object();

        int workerThreads = Environment.ProcessorCount;
        ThreadPool.SetMinThreads(workerThreads, workerThreads);

        ManualResetEventSlim resetEvent = new ManualResetEventSlim(false);

        foreach (string sourceFile in files)
        {
            string targetFile = Path.Combine(targetDirectory, Path.GetFileName(sourceFile));

            ThreadPool.QueueUserWorkItem(state =>
            {
                try
                {
                    CopyFile(sourceFile, targetFile);
                    lock (lockObject)
                    {
                        copiedFiles++;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An exception occurred while copying a file: {ex}");
                }
                finally
                {
                    if (Interlocked.Decrement(ref totalFiles) == 0)
                    {
                        resetEvent.Set();
                    }
                }
            });
        }

        resetEvent.Wait();
        Console.WriteLine($"Total files: {files.Length}");
        Console.WriteLine($"Copied files: {copiedFiles}");
    }

    static void CopyFile(string sourceFile, string targetFile)
    {
        using FileStream sourceStream = File.Open(sourceFile, FileMode.Open, FileAccess.Read, FileShare.Read);
        using FileStream targetStream = File.Create(targetFile);
        sourceStream.CopyTo(targetStream);
    }
}