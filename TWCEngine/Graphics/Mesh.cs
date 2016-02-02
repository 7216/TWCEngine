using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System.Collections.Generic;

namespace TWCEngine.Graphics
{
    class Mesh : Renderable
    {
        public Mesh()
        {

        }

        public Mesh(float[] data, uint[] indices, string textureName)
        {
            vbo = new VBO();
            vao = new VAO();
            ebo = new EBO();

            texture = TextureManager.GetTextureID(textureName);

            shader = new Shader(System.IO.File.ReadAllText("Shaders/Mesh/mesh_vert.glsl"), System.IO.File.ReadAllText("Shaders/Mesh/mesh_frag.glsl"));

            vao.Enable();
            vbo.BufferData(data);
            ebo.BufferData(indices);
            vao.Disable();
        }

        public static Mesh CreateMeshFromOBJ(string filePath)
        {
            List<float> data = new List<float>();
            List<uint> indices = new List<uint>();

            string[] lines = System.IO.File.ReadAllLines(filePath);

            List<Vector3> vertices = new List<Vector3>();
            List<Vector3> normals = new List<Vector3>();
            List<Vector2> textureCoordinates = new List<Vector2>();

            foreach (string line in lines)
            {
                string[] chunks = line.Split(' ');

                if (chunks[0] == "v") // Vertice!
                {
                    float x = float.Parse(chunks[1]);
                    float y = float.Parse(chunks[2]);
                    float z = float.Parse(chunks[3]);
                    vertices.Add(new Vector3(x, y, z));
                }
                if (chunks[0] == "vt") // Texture Coordinate!
                {
                    float x = float.Parse(chunks[1]);
                    float y = float.Parse(chunks[2]);
                    textureCoordinates.Add(new Vector2(x, y));
                }
                if (chunks[0] == "vn") // Normal!
                {
                    float x = float.Parse(chunks[1]);
                    float y = float.Parse(chunks[2]);
                    float z = float.Parse(chunks[3]);
                    normals.Add(new Vector3(x, y, z));
                }
                if (chunks[0] == "f") // Face!
                {
                    string[] v1 = chunks[1].Split('/');
                    string[] v2 = chunks[2].Split('/');
                    string[] v3 = chunks[3].Split('/');

                    indices.Add(uint.Parse(v1[0]) - 1);
                    indices.Add(uint.Parse(v2[0]) - 1);
                    indices.Add(uint.Parse(v3[0]) - 1);


                    //data.Add(vertices[int.Parse(v1[0]) - 1].X);
                    //data.Add(vertices[int.Parse(v1[0]) - 1].Y);
                    //data.Add(vertices[int.Parse(v1[0]) - 1].Z);

                    //data.Add(normals[int.Parse(v1[2]) - 1].X);
                    //data.Add(normals[int.Parse(v1[2]) - 1].Y);
                    //data.Add(normals[int.Parse(v1[2]) - 1].Z);

                    //data.Add(textureCoordinates[int.Parse(v1[1]) - 1].X);
                    //data.Add(textureCoordinates[int.Parse(v1[1]) - 1].Y);





                    //data.Add(vertices[int.Parse(v2[0]) - 1].X);
                    //data.Add(vertices[int.Parse(v2[0]) - 1].Y);
                    //data.Add(vertices[int.Parse(v2[0]) - 1].Z);

                    //data.Add(normals[int.Parse(v2[2]) - 1].X);
                    //data.Add(normals[int.Parse(v2[2]) - 1].Y);
                    //data.Add(normals[int.Parse(v2[2]) - 1].Z);

                    //data.Add(textureCoordinates[int.Parse(v2[1]) - 1].X);
                    //data.Add(textureCoordinates[int.Parse(v2[1]) - 1].Y);





                    //data.Add(vertices[int.Parse(v3[0]) - 1].X);
                    //data.Add(vertices[int.Parse(v3[0]) - 1].Y);
                    //data.Add(vertices[int.Parse(v3[0]) - 1].Z);

                    //data.Add(normals[int.Parse(v3[2]) - 1].X);
                    //data.Add(normals[int.Parse(v3[2]) - 1].Y);
                    //data.Add(normals[int.Parse(v3[2]) - 1].Z);

                    //data.Add(textureCoordinates[int.Parse(v3[1]) - 1].X);
                    //data.Add(textureCoordinates[int.Parse(v3[1]) - 1].Y);
                }
            }
            int XYZ = 0;
            foreach (Vector3 vert in vertices)
            {
                data.Add(vert.X);
                data.Add(vert.Y);
                data.Add(vert.Z);

                //data.Add(normals[XYZ].X);
                //data.Add(normals[XYZ].Y);
                //data.Add(normals[XYZ].Z);

                data.Add(0.0f);
                data.Add(0.0f);
                data.Add(0.0f);
                
                data.Add(0.0f);
                data.Add(0.0f);

                XYZ++;
            }
            return new Mesh(data.ToArray(), indices.ToArray(), "");
        }
    }
}
