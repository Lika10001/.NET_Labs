namespace AssemblyExample;

[ExportClass("Red")]
public class ColorfulShape
{
    private string _shapeName;

    public ColorfulShape(string shapeName)
    {
        _shapeName = shapeName;
    }

    public void DisplayShape()
    {
        Console.WriteLine($"Shape: {_shapeName}");
    }
}