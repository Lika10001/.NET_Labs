namespace AssemblyExample;
public class Color
{
    private int _red;
    private int _green;
    private int _blue;

    public Color(int red, int green, int blue)
    {
        _red = red;
        _green = green;
        _blue = blue;
    }

    public void DisplayColor()
    {
        Console.WriteLine($"RGB: {_red}, {_green}, {_blue}");
    }
}
