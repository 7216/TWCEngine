using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DestMath.Types
{
    struct Vector4
    {
        public float x, y, z, w;

        #region Constructors
        public Vector4(float x = 0, float y = 0, float z = 0, float w = 0)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }
        #endregion

        #region Values
        public float Magnitude()
        {
            return (float)Math.Sqrt(x * x + y * y + z * z + w * w);
        }
        public static float Magnitude(Vector4 var)
        {
            return (float)Math.Sqrt(var.x * var.x + var.y * var.y + var.z * var.z + var.w * var.w);
        }
        public static float Magnitude(ref Vector4 var)
        {
            return (float)Math.Sqrt(var.x * var.x + var.y * var.y + var.z * var.z + var.w * var.w);
        }

        public float Length()
        {
            return Magnitude();
        }
        public static float Length(Vector4 var)
        {
            return Magnitude(var);
        }
        public static float Length(ref Vector4 var)
        {
            return Magnitude(ref var);
        }

        float Distance(Vector4 other)
        {
            return Magnitude(this - other);
        }
        float Distance(ref Vector4 other)
        {
            return Magnitude(this - other);
        }
        static float Distance(Vector4 a, Vector4 b)
        {
            return Magnitude(a - b);
        }
        static float Distance(ref Vector4 a, ref Vector4 b)
        {
            return Magnitude(a - b);
        }

        static float Dot(Vector4 a, Vector4 b)
        {
            return (a.x * b.x) + (a.y * b.y) + (a.z * b.z) + (a.w * b.w);
        }
        static Vector4 Cross(Vector4 a, Vector4 b)
        {
            return new Vector4((a.y * b.z) - (a.z * b.y), (a.z * b.x) - (a.x * b.z), (a.x * b.y) - (a.y * b.x), (a.x * b.w) - (a.w * b.x));
        }
        #endregion

        #region Methods
        public void Normalize()
        {
            float mag = Magnitude();
            x /= mag;
            y /= mag;
            z /= mag;
            w /= mag;
        }
        #endregion

        #region Operations
        void Add(Vector4 other)
        {
            x += other.x;
            y += other.y;
            z += other.z;
            w += other.w;
        }
        void Add(ref Vector4 other)
        {
            x += other.x;
            y += other.y;
            z += other.z;
            w += other.w;
        }
        void Substract(Vector4 other)
        {
            x -= other.x;
            y -= other.y;
            z -= other.z;
            w -= other.w;
        }
        void Substract(ref Vector4 other)
        {
            x -= other.x;
            y -= other.y;
            z -= other.z;
            w -= other.w;
        }
        void Multiply(Vector4 other)
        {
            x *= other.x;
            y *= other.y;
            z *= other.z;
            w *= other.w;
        }
        void Multiply(ref Vector4 other)
        {
            x *= other.x;
            y *= other.y;
            z *= other.z;
            w *= other.w;
        }
        void Divide(Vector4 other)
        {
            x /= other.x;
            y /= other.y;
            z /= other.z;
        }
        void Divide(ref Vector4 other)
        {
            x /= other.x;
            y /= other.y;
            z /= other.z;
            w /= other.w;
        }

        void Scale(ref Vector4 other)
        {
            Multiply(other);
        }
        void Scale(float x, float y, float z, float w)
        {
            this.x *= x;
            this.y *= y;
            this.z *= z;
            this.w *= w;
        }
        bool Equals(Vector4 other)
        {
            return (x == other.x && y == other.y && z == other.z && w == other.w);
        }
        bool Equals(ref Vector4 other)
        {
            return (x == other.x && y == other.y && z == other.z && w == other.w);
        }

        static Vector4 Add(Vector4 a, Vector4 b)
        {
            return new Vector4(a.x + b.x, a.y + b.y, a.z + b.z, a.w + b.w);
        }
        static Vector4 Add(ref Vector4 a,ref Vector4 b)
        {
            return new Vector4(a.x + b.x, a.y + b.y, a.z + b.z, a.w + b.w);
        }
        static Vector4 Substract(Vector4 a, Vector4 b)
        {
            return new Vector4(a.x - b.x, a.y - b.y, a.z - b.z, a.w - b.w);
        }
        static Vector4 Substract(ref Vector4 a, ref Vector4 b)
        {
            return new Vector4(a.x - b.x, a.y - b.y, a.z - b.z, a.w - b.w);
        }
        static Vector4 Multiply(Vector4 a, Vector4 b)
        {
            return new Vector4(a.x * b.x, a.y * b.y, a.z * b.z, a.w * b.w);
        }
        static Vector4 Multiply(ref Vector4 a, ref Vector4 b)
        {
            return new Vector4(a.x * b.x, a.y * b.y, a.z * b.z, a.w * b.w);
        }
        static Vector4 Divide(Vector4 a, Vector4 b)
        {
            return new Vector4(a.x / b.x, a.y / b.y, a.z / b.z, a.w / b.w);
        }
        static Vector4 Divide(ref Vector4 a, ref Vector4 b)
        {
            return new Vector4(a.x / b.x, a.y / b.y, a.z / b.z, a.w / b.w);
        }

        static Vector4 Multiply(Vector4 a, float b)
        {
            return new Vector4(a.x * b, a.y * b, a.z * b, a.w * b);
        }
        static Vector4 Multiply(ref Vector4 a, ref float b)
        {
            return new Vector4(a.x * b, a.y * b, a.z * b, a.w * b);
        }
        static Vector4 Divide(Vector4 a, float b)
        {
            return new Vector4(a.x / b, a.y / b, a.z / b, a.w / b);
        }
        static Vector4 Divide(ref Vector4 a, ref float b)
        {
            return new Vector4(a.x / b, a.y / b, a.z / b, a.w / b);
        }

        static bool Equals(Vector4 a, Vector4 b)
        {
            return a.Equals(b);
        }
        static bool Equals(ref Vector4 a, ref Vector4 b)
        {
            return a.Equals(b);
        }

        void Clamp(Vector4 min, Vector4 max)
        {
            x = DestMath.Clamp(ref x, ref min.x, ref max.x);
            y = DestMath.Clamp(ref y, ref min.y, ref max.y);
            z = DestMath.Clamp(ref z, ref min.z, ref max.z);
            w = DestMath.Clamp(ref w, ref min.w, ref max.w);
        }
        void Clamp(ref Vector4 min, ref Vector4 max)
        {
            x = DestMath.Clamp(ref x, ref min.x, ref max.x);
            y = DestMath.Clamp(ref y, ref min.y, ref max.y);
            z = DestMath.Clamp(ref z, ref min.z, ref max.z);
            z = DestMath.Clamp(ref w, ref min.w, ref max.w);
        }
        static Vector4 Clamp(Vector4 var, Vector4 min, Vector4 max)
        {
            return new Vector4(DestMath.Clamp(var.x, min.x, max.x), DestMath.Clamp(var.y, min.y, max.y), DestMath.Clamp(var.z, min.z, max.z), DestMath.Clamp(var.w, min.w, max.w));
        }
        static Vector4 Clamp(ref Vector4 var, ref Vector4 min, ref Vector4 max)
        {
            return new Vector4(DestMath.Clamp(var.x, min.x, max.x), DestMath.Clamp(var.y, min.y, max.y), DestMath.Clamp(var.z, min.z, max.z), DestMath.Clamp(var.w, min.w, max.w));
        }
        #endregion

        #region Constants
        static readonly Vector4 Zero = new Vector4(0, 0, 0, 0);
        static readonly Vector4 One = new Vector4(1, 1, 1, 1);
        #endregion

        #region Operators
        public static Vector4 operator +(Vector4 a, Vector4 b)
        {
            return Add(ref a, ref b);
        }
        public static Vector4 operator -(Vector4 a, Vector4 b)
        {
            return Substract(ref a, ref b);
        }
        public static Vector4 operator *(Vector4 a, Vector4 b)
        {
            return Multiply(ref a, ref b);
        }
        public static Vector4 operator /(Vector4 a, Vector4 b)
        {
            return Divide(ref a, ref b);
        }

        public static Vector4 operator *(Vector4 a, float b)
        {
            return Multiply(ref a, ref b);
        }
        public static Vector4 operator /(Vector4 a, float b)
        {
            return Divide(ref a, ref b);
        }

        public static bool operator ==(Vector4 a, Vector4 b)
        {
            return Equals(a, b);
        }
        public static bool operator !=(Vector4 a, Vector4 b)
        {
            return !Equals(a, b);
        }
        #endregion
    }
}
