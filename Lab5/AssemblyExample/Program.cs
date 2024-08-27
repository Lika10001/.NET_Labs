using System.Reflection;

namespace AssemblyExample;

abstract class Program
{
    
    static void Main(string[] args)
    {
        if (args.Length < 1)
        {
            Console.WriteLine("Usage: Program <assemblyPath>");
            return;
        }

        string assemblyPath = args[0];

        try
        {
            Assembly assembly = Assembly.LoadFrom(assemblyPath);

            var exportedClasses = assembly.GetTypes()
                .Where(t => t is { IsClass: true, IsPublic: true } && t.GetCustomAttribute<ExportClassAttribute>() != null);

            foreach (var exportedClass in exportedClasses)
            {
                Console.WriteLine($"Exported class: {exportedClass.FullName}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading assembly: {ex.Message}");
        }
        
        /* Color red = new Color(255, 0, 0);
        Color green = new Color(0, 255, 0);
        Color blue = new Color(0, 0, 255);
        
        ColorPalette palette = new ColorPalette();
        palette.AddColor(red);
        palette.AddColor(green);
        palette.AddColor(blue);
        
        Console.WriteLine("Color Palette:");
        palette.DisplayPalette();
        Console.WriteLine();
        
        ColorfulShape colorfulShape = new ColorfulShape("Square");
        ColorfulPattern colorfulPattern = new ColorfulPattern("Stripes");
        
        Console.WriteLine("Colorful Shape:");
        colorfulShape.GetType()
            .GetCustomAttributes(typeof(ColorAttribute), true)
            .Cast<ColorAttribute>()
            .ToList()
            .ForEach(attr => attr.DisplayColorName());

        Console.WriteLine("Colorful Pattern:");
        colorfulPattern.GetType()
            .GetCustomAttributes(typeof(ColorAttribute), true)
            .Cast<ColorAttribute>()
            .ToList()
            .ForEach(attr => attr.DisplayColorName());*/
        
    }
}