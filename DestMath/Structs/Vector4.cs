using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DestMath.Structs
{
    class Vector3
    {
        public float x = 0, y = 0, z = 0;

        #region Constructors
        public Vector3()
        {

        }
        public Vector3(float x, float y, float z)
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
        public float Length()
        {
            return Magnitude();
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

        static bool Equals(Vector3 a, Vector3 b)
        {
            return a.Equals(b);
        }
        static bool Equals(ref Vector3 a, ref Vector3 b)
        {
            return a.Equals(b);
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
