

using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;



namespace TWCEngine
{
    public static class TWCEngine
    {
        [STAThread]
        public static void Main(int resX, int resY)
        {

            Graphics.Sprite sprite = new Graphics.Sprite();
            Graphics.Mesh mesh = new Graphics.Mesh();
            using (var game = new GameWindow())
            {
                game.VSync = VSyncMode.On;
                game.Width = resX;
                game.Height = resY;
                
                game.Load += (sender, e) =>
                {
                    Console.WriteLine("Using OpenGL version: " + GL.GetString(StringName.Version));

                    
                    Graphics.TextureManager.LoadTexture("F:/DestWa/Pictures/artkleiner.png", "art");

                    // setup settings, load textures, sounds


                    sprite = new Graphics.Sprite("art", Vector3.Zero, Vector3.Zero, Vector3.One);
                    sprite.scale = new Vector3(1280, 720, 1);
                    sprite.position.X = 10;


                    mesh = Graphics.Mesh.CreateMeshFromOBJ("C:/Users/DestWa/Desktop/man.obj");
                    mesh.scale = new Vector3(1, 1, 1);
                    mesh.position.Z = 100;

                    GL.ClearColor(Color.Cornsilk);
                };

                game.Resize += (sender, e) =>
                {
                    GL.Viewport(0, 0, game.Width, game.Height);
                };

                game.UpdateFrame += (sender, e) =>
                {
                    // add game logic, input handling
                    if (game.Keyboard[Key.Escape])
                    {
                        game.Exit();
                    }
                };
                
                game.RenderFrame += (sender, e) =>
                {
                    // render graphics
                    GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

                    Graphics.Renderer.DrawSprite(sprite);
                    //mesh.rotation.X += 0.01f;
                    //mesh.rotation.Y += 0.01f;

                    Graphics.Renderer.activeCamera.location.Z -= 0.1f;
                    Graphics.Renderer.DrawMesh(mesh);

                    game.SwapBuffers();
                };

                // Run the game at 60 updates per second
                game.Run(60.0);
            }
        }
    }
}
