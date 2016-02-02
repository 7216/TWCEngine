using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
namespace TWCEngine
{
    class Shader : IDisposable
    {
        public int Program = 0;
        private Dictionary<string, int> Variables = new Dictionary<string, int>();

        public enum Type
        {
            Vertex = 0x1,
            Fragment = 0x2
        }

        public static bool IsSupported
        {
            get
            {
                return (new Version(GL.GetString(StringName.Version).Substring(0, 3)) >= new Version(2, 0) ? true : false); // Magical shader magic
            }
        }
        #region constructors
        public Shader()
        {
            if (!IsSupported)
            {
                // TODO: cool logging system to cool console
                Console.WriteLine("Failed to create Shader." +
                    Environment.NewLine + "Your system doesn't support Shader.", "Error");
                return;
            }
        }
        public Shader(string source, Type type)
        {
            if (!IsSupported)
            {
                // TODO: cool logging system to cool console
                Console.WriteLine("Failed to create Shader." +
                    Environment.NewLine + "Your system doesn't support Shader.", "Error");
                return;
            }

            if (type == Type.Vertex)
            {
                Compile(source, "");
            }
            else
            {

                Compile("", source);
            }
        }
        public Shader(string vsource, string fsource)
        {
            if (!IsSupported)
            {
                // TODO: cool logging system to cool console
                Console.WriteLine("Shader creation failed." +
                    Environment.NewLine + "System does not support shaders.", "Error");
                return;
            }

            Compile(vsource, fsource);
        }
        #endregion

        public bool Compile(string vertSource = "", string fragSource = "")
        {
            int status = -1;
            string info = "";

            if (vertSource == "" && fragSource == "")
            {
                // TODO: cool logging again
                Console.WriteLine("Shader compile failed." +
                    Environment.NewLine + "No source specified.", "Error");
                return false;
            }

            if (Program > 0)
            {
                // TODO: Delete shader
            }

            Variables.Clear();

            Program = GL.CreateProgram();

            if (vertSource != "")
            {
                int vertShader = GL.CreateShader(ShaderType.VertexShader);
                GL.ShaderSource(vertShader, vertSource);
                GL.CompileShader(vertShader);
                GL.GetShaderInfoLog(vertShader, out info);
                GL.GetShader(vertShader, ShaderParameter.CompileStatus, out status);

                if (status != 1)
                {
                    Console.WriteLine("Failed to Compile Vertex Shader." +
                        Environment.NewLine + info + Environment.NewLine + "Status Code: " + status.ToString());
                    GL.DeleteShader(vertShader);
                    GL.DeleteProgram(Program);
                    Program = 0;

                    return false;
                }

                GL.AttachShader(Program, vertShader);
                GL.DeleteShader(vertShader);
            }

            if (fragSource != "")
            {
                int fragShader = GL.CreateShader(ShaderType.FragmentShader);
                GL.ShaderSource(fragShader, fragSource);
                GL.CompileShader(fragShader);
                GL.GetShaderInfoLog(fragShader, out info);
                GL.GetShader(fragShader, ShaderParameter.CompileStatus, out status);

                if (status != 1)
                {
                    Console.WriteLine("Failed to Compile Fragment Shader." +
                        Environment.NewLine + info + Environment.NewLine + "Status Code: " + status.ToString());
                    GL.DeleteShader(fragShader);
                    GL.DeleteProgram(Program);
                    Program = 0;

                    return false;
                }
                
                GL.AttachShader(Program, fragShader);
                GL.DeleteShader(fragShader);
            }

            GL.LinkProgram(Program);
            GL.GetProgramInfoLog(Program, out info);
            GL.GetProgram(Program, GetProgramParameterName.LinkStatus, out status);

            if (status != 1)
            {
                Console.WriteLine("Failed to Link Shader." +
                    Environment.NewLine + info + Environment.NewLine + "Status Code: " + status.ToString());

                GL.DeleteProgram(Program);
                Program = 0;

                return false;
            }
            return true;
        }

        public void Enable()
        {
            GL.UseProgram(Program);
        }
        public void Disable()
        {
            GL.UseProgram(0);
        }
        #region Uniforms
        public int GetUniformLocation(string name)
        {
            return GL.GetUniformLocation(Program, name);
        }

        public void SetUniform1(string name, float value)
        {
            GL.Uniform1(GetUniformLocation(name), value);
        }
        public void SetUniform2(string name, Vector2 value)
        {
            GL.Uniform2(GetUniformLocation(name), value);
        }
        public void SetUniform3(string name, Vector3 value)
        {
            GL.Uniform3(GetUniformLocation(name), value);
        }
        public void SetUniform4(string name, Vector4 value)
        {
            GL.Uniform4(GetUniformLocation(name), value);
        }
        public void SetUniformMatrix4(string name, Matrix4 value)
        {
            GL.UniformMatrix4(GetUniformLocation(name), false, ref value);
        }
        #endregion

        public void Dispose()
        {
            if (Program != 0)
                GL.DeleteProgram(Program);
        }
    }
}
