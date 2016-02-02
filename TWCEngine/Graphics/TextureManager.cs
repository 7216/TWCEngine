using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System.Drawing.Imaging;
using System.Collections.Generic;

namespace TWCEngine.Graphics
{
    public static class TextureManager
    {
        static Dictionary<string, int> Textures = new Dictionary<string, int>();

        private static int LoadFromBMP(string filename)
        {
            int id = GL.GenTexture();

            GL.BindTexture(TextureTarget.Texture2D, id);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMinFilter.Nearest);

            Bitmap bmp = new Bitmap(filename);
            BitmapData bmp_data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bmp_data.Width, bmp_data.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bmp_data.Scan0);

            GL.Enable(EnableCap.CullFace);

            bmp.UnlockBits(bmp_data);

            return id;
        }
        public static void BindTexture(string name)
        {
            GL.BindTexture(TextureTarget.Texture2D, GetTextureID(name));
        }
        public static void BindTexture(int id)
        {
            GL.BindTexture(TextureTarget.Texture2D, id);
        }
        public static void LoadTexture(string filename, string name)
        {
            Textures.Add(name, LoadFromBMP(filename));
        }

        public static int GetTextureID(string name)
        {
            int result = 0;
            Textures.TryGetValue(name, out result);
            return result;
        }
    }
}
