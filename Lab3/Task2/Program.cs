namespace Task2;

abstract class Program
{
    static void Main(string[] args)
    {
        const string pathToFile = "D:\\fromC\\downloads\\Lab1.cs";
        FileWrapper fileWrapper;
        try
        {
            using (fileWrapper = new FileWrapper(pathToFile))
            {
                string content = File.ReadAllText(pathToFile);
                Console.WriteLine("File content: " + content);
                Console.WriteLine("Checking handle, fileWrapper is not disposed.");
                Console.WriteLine("Is file handle closed? " + fileWrapper._handle.IsClosed);
            }
            Console.WriteLine("Checking handle, fileWrapper is disposed.");
            Console.WriteLine("Is file handle closed? " + fileWrapper._handle.IsClosed);
            fileWrapper.CheckDisposed();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
            
        Console.WriteLine("End of the program.");
    }
}