using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace TWCEngine.Graphics
{
    static class Renderer
    {
        static Matrix4 projectionMatrix = Matrix4.CreatePerspectiveFieldOfView(90.0f * ((float)Math.PI / 180), 1280.0f/720.0f, 1, 10000);//Matrix4.CreateOrthographic(1.77777777f, 1.0f, float.MinValue, float.MaxValue);
        public static Camera activeCamera = new Camera();

        public static void DrawSprite(Sprite sprite)
        {
            sprite.shader.Enable();
            sprite.shader.SetUniformMatrix4("projection", projectionMatrix);
            sprite.shader.SetUniformMatrix4("transform",  sprite.GetTransformMatrix());

            TextureManager.BindTexture(sprite.texture);

            sprite.vao.Enable();
            sprite.ebo.Enable();
            sprite.vbo.Enable();
            

            GL.DrawElements(PrimitiveType.Triangles, sprite.ebo.indiceCount, DrawElementsType.UnsignedInt, 0);
            //GL.DrawArrays(PrimitiveType.Quads, 0, sprite.vbo.verticeCount);

            sprite.vao.Disable();
            sprite.vbo.Disable();
            sprite.ebo.Disable();

            sprite.shader.Disable();
        }

        public static void DrawMesh(Mesh mesh)
        {
            mesh.shader.Enable();

            mesh.shader.SetUniformMatrix4("transform", projectionMatrix * activeCamera.GetMatrix4() * mesh.GetTransformMatrix());

            TextureManager.BindTexture(mesh.texture);

            mesh.vao.Enable();
            mesh.ebo.Enable();
            mesh.vbo.Enable();


            GL.DrawElements(PrimitiveType.Triangles, mesh.ebo.indiceCount, DrawElementsType.UnsignedInt, 0);
            //GL.DrawArrays(PrimitiveType.Quads, 0, mesh.vbo.verticeCount);

            mesh.vao.Disable();
            mesh.vbo.Disable();
            mesh.ebo.Disable();

            mesh.shader.Disable();
        }
    }
}
