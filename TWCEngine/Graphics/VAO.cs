using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace TWCEngine.Graphics
{
    class VAO : IDisposable
    {
        public int id = 0;

        public VAO()
        {
            id = GL.GenVertexArray();
        }

        public void Enable()
        {
            if (id != 0)
                GL.BindVertexArray(id);
        }
        public void Disable()
        {
            GL.BindVertexArray(0);
        }

        public void Dispose()
        {
            if (id != 0)
                GL.DeleteVertexArray(id);
        }
    }
}
