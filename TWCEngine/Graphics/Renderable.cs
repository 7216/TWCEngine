using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace TWCEngine.Graphics
{
    class Renderable
    {
        public VBO vbo;
        public VAO vao;
        public EBO ebo;

        public int texture;

        public Shader shader;

        public Vector3 position = Vector3.Zero, rotation = Vector3.Zero, scale = Vector3.One;
        
        public Matrix4 GetTransformMatrix()
        {
            Matrix4 transform = Matrix4.Identity;

            transform *= Matrix4.CreateScale(scale);

            transform *= Matrix4.CreateRotationX(rotation.X);
            transform *= Matrix4.CreateRotationY(rotation.Y);
            transform *= Matrix4.CreateRotationZ(rotation.Z);

            transform *= Matrix4.CreateTranslation(position);

            return transform;
        }
    }
}
