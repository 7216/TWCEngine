using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DestMath
{
    static class DestMath
    {
        public static float Clamp(float var, float min, float max)
        {
            return var < min ? min : (var > max ? max : var);
        }
        public static float Min(float a, float b)
        {
            return a < b ? a : b;
        }
        public static float Max(float a, float b)
        {
            return a > b ? a : b;
        }
        public static float Abs(float var)
        {
            return var >= 0 ? var : -var;
        }
    }
}
