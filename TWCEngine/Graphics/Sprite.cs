using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace TWCEngine.Graphics
{
    class Sprite : Renderable
    {
        public Sprite()
        {

        }
        public Sprite(string textureName, Vector3 pos, Vector3 rot, Vector3 s)
        {
            vbo = new VBO();
            vao = new VAO();
            ebo = new EBO();

            texture = TextureManager.GetTextureID(textureName);

            shader = new Shader(System.IO.File.ReadAllText("Shaders/Sprite/sprite_vert.glsl"), System.IO.File.ReadAllText("Shaders/Sprite/sprite_frag.glsl"));

            position = pos;
            rotation = rot;
            scale = s / 0.5f;

            float[] vertices = {
                // Positions          // Normals           // Texture Coords
                 0.5f,  0.5f, 0.0f,   0.0f, 0.0f, 1.0f,   0.0f, 0.0f,   // Top Right
                 0.5f, -0.5f, 0.0f,   0.0f, 0.0f, 1.0f,   0.0f, 1.0f,   // Bottom Right
                -0.5f, -0.5f, 0.0f,   0.0f, 0.0f, 1.0f,   1.0f, 1.0f,   // Bottom Left
                -0.5f,  0.5f, 0.0f,   0.0f, 0.0f, 1.0f,   1.0f, 0.0f    // Top Left 
            };
            uint[] indices =
            {
                0, 3, 2, 2, 1, 0
            };

            vao.Enable();

            vbo.BufferData(vertices);
            ebo.BufferData(indices);

            vao.Disable();
        }
    }
}
