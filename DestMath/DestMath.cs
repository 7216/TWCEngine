using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DestMath
{
    static class DestMath
    {
        static readonly double dPI = 3.14159265358979323846;
        static readonly float PI = 3.14159265359f;
        public static float Clamp(float var, float min, float max)
        {
            return var < min ? min : (var > max ? max : var);
        }
        public static float Clamp(ref float var, ref float min, ref float max)
        {
            return var < min ? min : (var > max ? max : var);
        }

        public static float Min(float a, float b)
        {
            return a < b ? a : b;
        }
        public static float Min(ref float a, ref float b)
        {
            return a < b ? a : b;
        }

        public static float Max(float a, float b)
        {
            return a > b ? a : b;
        }
        public static float Max(ref float a, ref float b)
        {
            return a > b ? a : b;
        }

        public static float Abs(float var)
        {
            return var >= 0 ? var : -var;
        }
        public static float Abs(ref float var)
        {
            return var >= 0 ? var : -var;
        }

        public static float ToRadians(float angle)
        {
            return angle * (180 / PI);
        }
    }
}
