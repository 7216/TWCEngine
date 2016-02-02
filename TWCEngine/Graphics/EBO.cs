using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace TWCEngine.Graphics
{
    class EBO : IDisposable
    {
        public int id = 0;
        public int indiceCount = 0;

        public EBO()
        {
            id = GL.GenBuffer();
        }

        public void BufferData(uint[] indices)
        {
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, id);

            GL.BufferData(BufferTarget.ElementArrayBuffer, (IntPtr)(indices.Length * sizeof(uint)), indices, BufferUsageHint.StaticDraw);

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);

            indiceCount = indices.Length;
        }

        public void Enable()
        {
            if (id != 0)
                GL.BindBuffer(BufferTarget.ElementArrayBuffer, id);
        }
        public void Disable()
        {
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);
        }

        public void Dispose()
        {
            if (id != 0)
                GL.DeleteBuffer(id);
        }
    }
}
