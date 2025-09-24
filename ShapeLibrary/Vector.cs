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

        public static Vector operator +(Vector vector1, Vector vector2)
        {
            float xValue = vector1.X + vector2.X;
            float yValue = vector1.Y + vector2.Y;
            
            return new Vector(xValue, yValue);
        }

        public static Vector operator -(Vector vector1, Vector vector2)
        {
            float xValue = (vector1.X - vector2.X);
            float yValue = (vector1.Y - vector2.Y);
            
            return new Vector(xValue, yValue);
        }

        public static Vector operator *(Vector vector, float scalar)
        {
            float xValue = vector.X * scalar;
            float yValue = vector.Y * scalar;
            
            return new Vector(xValue, yValue);
        }

        public static Vector operator /(Vector vector, float scalar)
        {
            if (scalar == 0)
            {
                throw new ArgumentException("ERROR: Scalar value can not be 0.");
            }
            
            float xValue = vector.X / scalar;
            float yValue = vector.Y / scalar;
            
            return new Vector(xValue, yValue);
        }

        public static float Magnitude(Vector vector)
        {
            float sumOfSquares = (vector.X * vector.X) + (vector.Y * vector.Y);
            float magnitude = (float)Math.Sqrt(sumOfSquares);

            return magnitude;
        }

        public static Vector Normalize(Vector vector)
        {
            float vectorMagnitude = Magnitude(vector);

            Vector normalizedVector = vector / vectorMagnitude;

            return normalizedVector;
        }

        public override string ToString()
        {
            return $"{this.X}, {this.Y}";
        }
    }
}
