using System.Drawing;

namespace ShapeLibrary;

public struct Colour
{
    public int Red { get; }
    public int Green { get; }
    public int Blue { get; }
    
    public Colour(int red, int green, int blue)
    {
        Red = ClampColorValue(red);
        Green = ClampColorValue(green);
        Blue = ClampColorValue(blue);
    }

    public static int ClampColorValue(int colorValue)
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

    public static Colour operator +(Colour colour1, Colour colour2) {
        return new Colour
            (ClampColorValue(colour1.Red + colour2.Red), 
            ClampColorValue(colour1.Green + colour2.Green),
            ClampColorValue(colour1.Blue + colour2.Blue)
            );
    }

    public static Colour operator -(Colour colour1, Colour colour2) {
        return new Colour
            (ClampColorValue(colour1.Red - colour2.Red),
            ClampColorValue(colour1.Green - colour2.Green),
            ClampColorValue(colour1.Blue - colour2.Blue)
            );
    }

    public static Colour operator *(Colour colour1, Colour colour2)
    {
        return new Colour
            (ClampColorValue(colour1.Red * colour2.Red),
            ClampColorValue(colour1.Green * colour2.Green),
            ClampColorValue(colour1.Blue * colour2.Blue)
            );
    }

    public static bool operator ==(Colour colour1, Colour colour2)
    {
        return colour1.Red == colour2.Red && colour1.Green == colour2.Green && colour1.Blue == colour2.Blue;
    }

    public static bool operator !=(Colour colour1, Colour colour2)
    {
        return !(colour1 == colour2);
    }

}
