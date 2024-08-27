namespace AssemblyExample;

public class ColorPalette
{
    private List<Color> _colors;

    public ColorPalette()
    {
        _colors = new List<Color>();
    }

    public void AddColor(Color color)
    {
        _colors.Add(color);
    }

    public void DisplayPalette()
    {
        foreach (Color color in _colors)
        {
            color.DisplayColor();
        }
    }
}