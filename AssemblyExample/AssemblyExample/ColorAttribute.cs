namespace AssemblyExample;

[AttributeUsage(AttributeTargets.Class)]
public class ExportClassAttribute : Attribute
{
    private string _colorName;

    public ExportClassAttribute(string colorName)
    {
        _colorName = colorName;
    }

    public void DisplayColorName()
    {
        Console.WriteLine($"Color Name: {_colorName}");
    }
}