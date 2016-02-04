using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DestMath.Types
{
    struct Vector2
    {
        public float x, y;

        #region Constructors
        public Vector2(float x = 0, float y = 0)
        {
            this.x = x;
            this.y = y;
        }
        #endregion

        #region Values
        public float Magnitude()
        {
            return (float)Math.Sqrt(x * x + y * y);
        }
        public static float Magnitude(Vector2 var)
        {
            return (float)Math.Sqrt(var.x * var.x + var.y * var.y);
        }
        public static float Magnitude(ref Vector2 var)
        {
            return (float)Math.Sqrt(var.x * var.x + var.y * var.y);
        }

        public float Length()
        {
            return Magnitude();
        }
        public static float Length(Vector2 var)
        {
            return Magnitude(var);
        }
        public static float Length(ref Vector2 var)
        {
            return Magnitude(ref var);
        }

        float Distance(Vector2 other)
        {
            return Magnitude(this - other);
        }
        float Distance(ref Vector2 other)
        {
            return Magnitude(this - other);
        }
        static float Distance(Vector2 a, Vector2 b)
        {
            return Magnitude(a - b);
        }
        static float Distance(ref Vector2 a, ref Vector2 b)
        {
            return Magnitude(a - b);
        }

        static float Dot(Vector2 a, Vector2 b)
        {
            return (a.x * b.x) + (a.y * b.y);
        }
        static Vector2 Cross(Vector2 a, Vector2 b)
        {
            return new Vector2(0, 0);
        }
        #endregion

        #region Methods
        public void Normalize()
        {
            float mag = Magnitude();
            x /= mag;
            y /= mag;
        }
        #endregion

        #region Operations
        void Add(Vector2 other)
        {
            x += other.x;
            y += other.y;
        }
        void Add(ref Vector2 other)
        {
            x += other.x;
            y += other.y;
        }
        void Substract(Vector2 other)
        {
            x -= other.x;
            y -= other.y;
        }
        void Substract(ref Vector2 other)
        {
            x -= other.x;
            y -= other.y;
        }
        void Multiply(Vector2 other)
        {
            x *= other.x;
            y *= other.y;
        }
        void Multiply(ref Vector2 other)
        {
            x *= other.x;
            y *= other.y;
        }
        void Divide(Vector2 other)
        {
            x /= other.x;
            y /= other.y;
        }
        void Divide(ref Vector2 other)
        {
            x /= other.x;
            y /= other.y;
        }

        void Scale(ref Vector2 other)
        {
            Multiply(other);
        }
        void Scale(float x, float y)
        {
            this.x *= x;
            this.y *= y;
        }
        bool Equals(Vector2 other)
        {
            return (x == other.x && y == other.y);
        }
        bool Equals(ref Vector2 other)
        {
            return (x == other.x && y == other.y);
        }

        static Vector2 Add(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x + b.x, a.y + b.y);
        }
        static Vector2 Add(ref Vector2 a,ref Vector2 b)
        {
            return new Vector2(a.x + b.x, a.y + b.y);
        }
        static Vector2 Substract(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x - b.x, a.y - b.y);
        }
        static Vector2 Substract(ref Vector2 a, ref Vector2 b)
        {
            return new Vector2(a.x - b.x, a.y - b.y);
        }
        static Vector2 Multiply(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x * b.x, a.y * b.y);
        }
        static Vector2 Multiply(ref Vector2 a, ref Vector2 b)
        {
            return new Vector2(a.x * b.x, a.y * b.y);
        }
        static Vector2 Divide(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x / b.x, a.y / b.y);
        }
        static Vector2 Divide(ref Vector2 a, ref Vector2 b)
        {
            return new Vector2(a.x / b.x, a.y / b.y);
        }

        static Vector2 Multiply(Vector2 a, float b)
        {
            return new Vector2(a.x * b, a.y * b);
        }
        static Vector2 Multiply(ref Vector2 a, ref float b)
        {
            return new Vector2(a.x * b, a.y * b);
        }
        static Vector2 Divide(Vector2 a, float b)
        {
            return new Vector2(a.x / b, a.y / b);
        }
        static Vector2 Divide(ref Vector2 a, ref float b)
        {
            return new Vector2(a.x / b, a.y / b);
        }

        static bool Equals(Vector2 a, Vector2 b)
        {
            return a.Equals(b);
        }
        static bool Equals(ref Vector2 a, ref Vector2 b)
        {
            return a.Equals(b);
        }

        void Clamp(Vector2 min, Vector2 max)
        {
            x = DestMath.Clamp(x, min.x, max.x);
            y = DestMath.Clamp(y, min.y, max.y);
        }
        void Clamp(ref Vector2 min, ref Vector2 max)
        {
            x = DestMath.Clamp(x, min.x, max.x);
            y = DestMath.Clamp(y, min.y, max.y);
        }
        static Vector2 Clamp(Vector2 var, Vector2 min, Vector2 max)
        {
            return new Vector2(DestMath.Clamp(var.x, min.x, max.x), DestMath.Clamp(var.y, min.y, max.y));
        }
        static Vector2 Clamp(ref Vector2 var, ref Vector2 min, ref Vector2 max)
        {
            return new Vector2(DestMath.Clamp(var.x, min.x, max.x), DestMath.Clamp(var.y, min.y, max.y));
        }
        #endregion

        #region Constants
        public static readonly Vector2 Zero = new Vector2(0, 0);
        public static readonly Vector2 One = new Vector2(1, 1);
        #endregion

        #region Operators
        public static Vector2 operator +(Vector2 a, Vector2 b)
        {
            return Add(ref a, ref b);
        }
        public static Vector2 operator -(Vector2 a, Vector2 b)
        {
            return Substract(ref a, ref b);
        }
        public static Vector2 operator *(Vector2 a, Vector2 b)
        {
            return Multiply(ref a, ref b);
        }
        public static Vector2 operator /(Vector2 a, Vector2 b)
        {
            return Divide(ref a, ref b);
        }

        public static Vector2 operator *(Vector2 a, float b)
        {
            return Multiply(ref a, ref b);
        }
        public static Vector2 operator /(Vector2 a, float b)
        {
            return Divide(ref a, ref b);
        }

        public static bool operator ==(Vector2 a, Vector2 b)
        {
            return Equals(a, b);
        }
        public static bool operator !=(Vector2 a, Vector2 b)
        {
            return !Equals(a, b);
        }
        #endregion
    }
}
