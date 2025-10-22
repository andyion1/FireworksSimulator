using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLibrary
{
    public struct Vector
    {
        public float X { get; }
        public float Y { get; }

        public Vector(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }

        public Vector(Vector vector)
        {
            this.X = vector.X;
            this.Y = vector.Y;
        }

        // adds two vectors
        public static Vector operator +(Vector vector1, Vector vector2)
        {
            return new Vector(vector1.X + vector2.X, vector1.Y + vector2.Y);
        }

        // subtracts one vector from another
        public static Vector operator -(Vector vector1, Vector vector2)
        {
            return new Vector(vector1.X - vector2.X, vector1.Y - vector2.Y);
        }

        // scales a vector by a float
        public static Vector operator *(Vector vector, float scalar)
        {
            return new Vector(vector.X * scalar, vector.Y * scalar);
        }

        // divides a vector by a float
        public static Vector operator /(Vector vector, float scalar)
        {
            if (scalar == 0)
                throw new DivideByZeroException("ERROR: Cannot divide a vector by 0.");

            return new Vector(vector.X / scalar, vector.Y / scalar);
        }

        // calculates vector magnitude (length)
        public static float Magnitude(Vector vector)
        {
            return (float)Math.Sqrt((vector.X * vector.X) + (vector.Y * vector.Y));
        }

        // returns a normalized (unit length) version
        public static Vector Normalize(Vector vector)
        {
            float vectorMagnitude = Magnitude(vector);

            if (vectorMagnitude == 0)
                return new Vector(0, 0);

            return vector / vectorMagnitude;
        }

        public override string ToString()
        {
            return $"({this.X}, {this.Y})";
        }
    }
}
