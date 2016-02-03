using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DestMath.Types
{
    class Vector3
    {
        public float x = 0, y = 0, z = 0;

        #region Constructors
        public Vector3()
        {
        }
        public Vector3(float x = 0, float y = 0, float z = 0)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        #endregion

        #region Values
        public float Magnitude()
        {
            return (float)Math.Sqrt(x * x + y * y + z * z);
        }
        public static float Magnitude(Vector3 var)
        {
            return (float)Math.Sqrt(var.x * var.x + var.y * var.y + var.z * var.z);
        }
        public static float Magnitude(ref Vector3 var)
        {
            return (float)Math.Sqrt(var.x * var.x + var.y * var.y + var.z * var.z);
        }

        public float Length()
        {
            return Magnitude();
        }
        public static float Length(Vector3 var)
        {
            return Magnitude(var);
        }
        public static float Length(ref Vector3 var)
        {
            return Magnitude(ref var);
        }

        float Distance(Vector3 other)
        {
            return Magnitude(this - other);
        }
        float Distance(ref Vector3 other)
        {
            return Magnitude(this - other);
        }
        static float Distance(Vector3 a, Vector3 b)
        {
            return Magnitude(a - b);
        }
        static float Distance(ref Vector3 a, ref Vector3 b)
        {
            return Magnitude(a - b);
        }

        static float Dot(Vector3 a, Vector3 b)
        {
            return (a.x * b.x) + (a.y * b.y) + (a.z * b.z);
        }
        static Vector3 Cross(Vector3 a, Vector3 b)
        {
            return new Vector3((a.y * b.z) - (a.z * b.y), (a.z * b.x) - (a.x * b.z), (a.x * b.y) - (a.y * b.x));
        }
        static Vector3 TriangleNormal(Vector3 a, Vector3 b, Vector3 c)
        {
            return Cross(b - a, c - a);
        }
        #endregion

        #region Methods
        public void Normalize()
        {
            float mag = Magnitude();
            x /= mag;
            y /= mag;
            z /= mag;
        }
        #endregion

        #region Operations
        void Add(Vector3 other)
        {
            x += other.x;
            y += other.y;
            z += other.z;
        }
        void Add(ref Vector3 other)
        {
            x += other.x;
            y += other.y;
            z += other.z;
        }
        void Substract(Vector3 other)
        {
            x -= other.x;
            y -= other.y;
            z -= other.z;
        }
        void Substract(ref Vector3 other)
        {
            x -= other.x;
            y -= other.y;
            z -= other.z;
        }
        void Multiply(Vector3 other)
        {
            x *= other.x;
            y *= other.y;
            z *= other.z;
        }
        void Multiply(ref Vector3 other)
        {
            x *= other.x;
            y *= other.y;
            z *= other.z;
        }
        void Divide(Vector3 other)
        {
            x /= other.x;
            y /= other.y;
            z /= other.z;
        }
        void Divide(ref Vector3 other)
        {
            x /= other.x;
            y /= other.y;
            z /= other.z;
        }

        void Scale(ref Vector3 other)
        {
            Multiply(other);
        }
        void Scale(float x, float y, float z)
        {
            this.x *= x;
            this.y *= y;
            this.z *= z;
        }
        bool Equals(Vector3 other)
        {
            return (x == other.x && y == other.y && z == other.z);
        }
        bool Equals(ref Vector3 other)
        {
            return (x == other.x && y == other.y && z == other.z);
        }

        static Vector3 Add(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x + b.x, a.y + b.y, a.z + b.z);
        }
        static Vector3 Add(ref Vector3 a,ref Vector3 b)
        {
            return new Vector3(a.x + b.x, a.y + b.y, a.z + b.z);
        }
        static Vector3 Substract(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x - b.x, a.y - b.y, a.z - b.z);
        }
        static Vector3 Substract(ref Vector3 a, ref Vector3 b)
        {
            return new Vector3(a.x - b.x, a.y - b.y, a.z - b.z);
        }
        static Vector3 Multiply(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x * b.x, a.y * b.y, a.z * b.z);
        }
        static Vector3 Multiply(ref Vector3 a, ref Vector3 b)
        {
            return new Vector3(a.x * b.x, a.y * b.y, a.z * b.z);
        }
        static Vector3 Divide(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x / b.x, a.y / b.y, a.z / b.z);
        }
        static Vector3 Divide(ref Vector3 a, ref Vector3 b)
        {
            return new Vector3(a.x / b.x, a.y / b.y, a.z / b.z);
        }

        static Vector3 Multiply(Vector3 a, float b)
        {
            return new Vector3(a.x * b, a.y * b, a.z * b);
        }
        static Vector3 Multiply(ref Vector3 a, ref float b)
        {
            return new Vector3(a.x * b, a.y * b, a.z * b);
        }
        static Vector3 Divide(Vector3 a, float b)
        {
            return new Vector3(a.x / b, a.y / b, a.z / b);
        }
        static Vector3 Divide(ref Vector3 a, ref float b)
        {
            return new Vector3(a.x / b, a.y / b, a.z / b);
        }

        static bool Equals(Vector3 a, Vector3 b)
        {
            return a.Equals(b);
        }
        static bool Equals(ref Vector3 a, ref Vector3 b)
        {
            return a.Equals(b);
        }

        void Clamp(Vector3 min, Vector3 max)
        {
            x = DestMath.Clamp(x, min.x, max.x);
            y = DestMath.Clamp(y, min.y, max.y);
            z = DestMath.Clamp(z, min.z, max.z);
        }
        void Clamp(ref Vector3 min, ref Vector3 max)
        {
            x = DestMath.Clamp(x, min.x, max.x);
            y = DestMath.Clamp(y, min.y, max.y);
            z = DestMath.Clamp(z, min.z, max.z);
        }
        static Vector3 Clamp(Vector3 var, Vector3 min, Vector3 max)
        {
            return new Vector3(DestMath.Clamp(var.x, min.x, max.x), DestMath.Clamp(var.y, min.y, max.y), DestMath.Clamp(var.z, min.z, max.z));
        }
        static Vector3 Clamp(ref Vector3 var, ref Vector3 min, ref Vector3 max)
        {
            return new Vector3(DestMath.Clamp(var.x, min.x, max.x), DestMath.Clamp(var.y, min.y, max.y), DestMath.Clamp(var.z, min.z, max.z));
        }
        #endregion

        #region Constants
        static readonly Vector3 Zero = new Vector3(0, 0, 0);
        static readonly Vector3 One = new Vector3(1, 1, 1);
        #endregion

        #region Operators
        public static Vector3 operator +(Vector3 a, Vector3 b)
        {
            return Add(ref a, ref b);
        }
        public static Vector3 operator -(Vector3 a, Vector3 b)
        {
            return Substract(ref a, ref b);
        }
        public static Vector3 operator *(Vector3 a, Vector3 b)
        {
            return Multiply(ref a, ref b);
        }
        public static Vector3 operator /(Vector3 a, Vector3 b)
        {
            return Divide(ref a, ref b);
        }

        public static Vector3 operator *(Vector3 a, float b)
        {
            return Multiply(ref a, ref b);
        }
        public static Vector3 operator /(Vector3 a, float b)
        {
            return Divide(ref a, ref b);
        }

        public static bool operator ==(Vector3 a, Vector3 b)
        {
            return Equals(a, b);
        }
        public static bool operator !=(Vector3 a, Vector3 b)
        {
            return !Equals(a, b);
        }
        #endregion
    }
}
