using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DestMath.Types
{
    struct Matrix4
    {
        float[] elements;

        #region Constructors
        public Matrix4(float M00 = 0, float M01 = 0, float M02 = 0, float M03 = 0, float M10 = 0, float M11 = 0, float M12 = 0, float M13 = 0, float M20 = 0, float M21 = 0, float M22 = 0, float M23 = 0, float M30 = 0, float M31 = 0, float M32 = 0, float M33 = 0)
        {
            elements = new float[4 * 4];

            elements[0] = M00;
            elements[1] = M01;
            elements[2] = M02;
            elements[3] = M03;
            elements[4] = M10;
            elements[5] = M11;
            elements[6] = M12;
            elements[7] = M13;
            elements[8] = M20;
            elements[9] = M21;
            elements[10] = M22;
            elements[11] = M23;
            elements[12] = M30;
            elements[13] = M31;
            elements[14] = M32;
            elements[15] = M03;
        }
        public Matrix4(Vector4 r1, Vector4 r2, Vector4 r3, Vector4 r4)
        {
            elements = new float[4 * 4];

            elements[0] = r1.x;
            elements[1] = r1.y;
            elements[2] = r1.z;
            elements[3] = r1.w;
            elements[4] = r2.x;
            elements[5] = r2.y;
            elements[6] = r2.z;
            elements[7] = r2.w;
            elements[8] = r3.x;
            elements[9] = r3.y;
            elements[10] = r3.z;
            elements[11] = r3.w;
            elements[12] = r4.x;
            elements[13] = r4.y;
            elements[14] = r4.z;
            elements[15] = r4.w;
        }
        #endregion

        #region Values
        static Matrix4 Orthographic(float left, float right, float top, float bottom, float znear, float zfar)
        {
            Matrix4 matrix = Matrix4.Identity;

            matrix.elements[0 + 0 * 4] = 2.0f / (right - left);
            matrix.elements[1 + 1 * 4] = 2.0f / (top - bottom);
            matrix.elements[2 + 2 * 4] = 2.0f / (znear - zfar);

            matrix.elements[0 + 3 * 4] = (left + right) / (left - right);
            matrix.elements[1 + 3 * 4] = (bottom + top) / (bottom - top);
            matrix.elements[2 + 3 * 4] = (zfar + znear) / (zfar - znear);

            return matrix;
        }
        static Matrix4 Perspective(float fov, float aspectRatio, float znear, float zfar)
        {
            float q = 1.0f / (float)Math.Tan(DestMath.ToRadians(fov * 0.5f));
            float a = q / aspectRatio;
            float b = (znear + zfar) / (znear - zfar);
            float c = (2.0f * znear * zfar) / (znear - zfar);

            Matrix4 matrix = Matrix4.Identity;
            matrix.elements[0 + 0 * 4] = a;
            matrix.elements[1 + 1 * 4] = q;
            matrix.elements[2 + 2 * 4] = b;
            matrix.elements[3 + 2 * 4] = -1.0f;
            matrix.elements[2 + 3 * 4] = c;

            return matrix;
        }
        #endregion

        #region Methods
        public Matrix4 Translate(Vector3 translation)
	    {

            Matrix4 matrix = Matrix4.Identity;

            matrix.elements[0 + 3 * 4] = translation.x;
		    matrix.elements[1 + 3 * 4] = translation.y;
		    matrix.elements[2 + 3 * 4] = translation.z;

		    return matrix;
	    }
        Matrix4 Rotate(Vector3 axis, float angle)
	    {

            float radians = DestMath.ToRadians(angle);
            float cosine = (float)Math.Cos(radians);
            float sine = (float)Math.Sin(radians);

            float oneMinusCosine = 1.0f - cosine;

            Matrix4 matrix = Matrix4.Identity;

            matrix.elements[0 + 0 * 4] = axis.x* oneMinusCosine + cosine;
		    matrix.elements[1 + 0 * 4] = axis.y* axis.x * oneMinusCosine + axis.z* sine;
            matrix.elements[2 + 0 * 4] = axis.x* axis.z * oneMinusCosine - axis.y* sine;

            matrix.elements[0 + 1 * 4] = axis.x* axis.y * oneMinusCosine - axis.z* sine;
            matrix.elements[1 + 1 * 4] = axis.y* oneMinusCosine + cosine;
		    matrix.elements[2 + 1 * 4] = axis.y* axis.z * oneMinusCosine + axis.x* sine;

            matrix.elements[0 + 2 * 4] = axis.x* axis.z * oneMinusCosine + axis.y* sine;
            matrix.elements[1 + 2 * 4] = axis.y* axis.z * oneMinusCosine - axis.x* sine;
            matrix.elements[2 + 2 * 4] = axis.z* oneMinusCosine + cosine;

		    return matrix;
	    }
        Matrix4 Scale(Vector3 scale)
	    {

            Matrix4 matrix = Matrix4.Identity;
            matrix.elements[0 + 0 * 4] = scale.x;
		    matrix.elements[1 + 1 * 4] = scale.y;
		    matrix.elements[2 + 2 * 4] = scale.z;

		    return matrix;
	    }
        #endregion

        #region Operations
        void Multiply(Matrix4 other)
        {
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    float sum = 0.0f;
                    for (int i = 0; i < 4; i++)
                    {
                        sum += elements[x + i * 4] * other.elements[i + y * 4];
                    }
                    elements[x + y * 4] = sum;
                }
            }
        }
        void Multiply(ref Matrix4 other)
        {
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    float sum = 0.0f;
                    for (int i = 0; i < 4; i++)
                    {
                        sum += elements[x + i * 4] * other.elements[i + y * 4];
                    }
                    elements[x + y * 4] = sum;
                }
            }
        }
        static Matrix4 Multiply(Matrix4 a, Matrix4 b)
        {
            Matrix4 result = a;
            float sum = 0.0f;
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    sum = 0.0f;
                    for (int i = 0; i < 4; i++)
                    {
                        sum += result.elements[x + i * 4] * b.elements[i + y * 4];
                    }
                    result.elements[x + y * 4] = sum;
                }
            }
            return result;
        }
        static Matrix4 Multiply(ref Matrix4 a, ref Matrix4 b)
        {
            Matrix4 result = a;
            float sum = 0.0f;
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    sum = 0.0f;
                    for (int i = 0; i < 4; i++)
                    {
                        sum += result.elements[x + i * 4] * b.elements[i + y * 4];
                    }
                    result.elements[x + y * 4] = sum;
                }
            }
            return result;
        }
        #endregion

        #region Constants
        static readonly Matrix4 Identity = new Matrix4(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1);
        #endregion

        #region Operators
        public static Matrix4 operator *(Matrix4 a, Matrix4 b)
        {
            return Multiply(ref a, ref b);
        }
        #endregion
    }
}
