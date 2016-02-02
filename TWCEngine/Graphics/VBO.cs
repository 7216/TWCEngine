using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace TWCEngine.Graphics
{
    class VBO : IDisposable
    {
        public int id = 0;
        public int verticeCount = 0;

        public VBO()
        {
            id = GL.GenBuffer();
        }

        public void BufferData(float[] data)
        {
            if (id == 0)
                return;
            GL.BindBuffer(BufferTarget.ArrayBuffer, id);

            GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(data.Length * sizeof(float)), data, BufferUsageHint.StaticDraw);

            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 8 * sizeof(float), 0);
            GL.VertexAttribPointer(1, 3, VertexAttribPointerType.Float, false, 8 * sizeof(float), (3 * sizeof(float)));
            GL.VertexAttribPointer(2, 2, VertexAttribPointerType.Float, false, 8 * sizeof(float), (6 * sizeof(float)));

            GL.EnableVertexAttribArray(0);
            GL.EnableVertexAttribArray(1);
            GL.EnableVertexAttribArray(2);

            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

            verticeCount = data.Length;
        }

        public void Enable()
        {
            if (id != 0)
                GL.BindBuffer(BufferTarget.ArrayBuffer, id);
        }
        public void Disable()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        }

        public void Dispose()
        {
            if (id != 0)
                GL.DeleteBuffer(id);
        }
    }
}
