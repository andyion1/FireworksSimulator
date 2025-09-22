namespace ShapeLibrary;

public struct Colour
{
    public int Red { get; }
    public int Green { get; }
    public int Blue { get; }
    
    public Colour(int red, int green, int blue)
    {
        Red = ClampColorValue(Red);
        Green = ClampColorValue(Green);
        Blue = ClampColorValue(Blue);
    }

    public int ClampColorValue(int colorValue)
    {
        if (colorValue < 0)
        {
            return 0;
        }
        else if (colorValue > 255)
        {
            return 255;
        }

        return colorValue;

    }
}
