namespace AssemblyExample;

[ExportClass("Blue")]
public class ColorfulPattern
{
    private string _patternName;

    public ColorfulPattern(string patternName)
    {
        _patternName = patternName;
    }

    public void DisplayPattern()
    {
        Console.WriteLine($"Pattern: {_patternName}");
    }
}