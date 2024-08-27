namespace DynamicList;

abstract class Program
{
    static void Main()
    {
        int[] initialItems = { 10, 20, 30, 44, -9, 0, 111};
        DynamicList<int> list = new DynamicList<int>(initialItems);
        Console.WriteLine("Initial Count: " + list.Count);
        Console.WriteLine("Items:");
        foreach (int item in list)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("Adding new element: 40");
        list.Add(40);
        Console.WriteLine("Count after adding new element: " + list.Count);
        Console.WriteLine("Items after adding new element:");
        foreach (int item in list)
        {
            Console.WriteLine(item);
        }
        
        Console.WriteLine("Removing one element: 20");
        bool isRemoved = list.Remove(20);
        Console.WriteLine("Is 20 removed? " + isRemoved);
        Console.WriteLine("Count after removing element: " + list.Count);
        Console.WriteLine("Items after removing element:");
        foreach (int item in list)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine("Removing 3 elements starting at index 3");
        list.RemoveAt(3, 3);
        Console.WriteLine("Items after removing 3 elements:");
        foreach (int item in list)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine("Clearing current list.");
        list.Clear();
        Console.WriteLine("Count after clearing the list: " + list.Count);
        
    }
}