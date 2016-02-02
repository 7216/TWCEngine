using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System.Collections.Generic;

namespace TWCEngine.Graphics
{
    class Camera
    {
        public Vector3 location, rotation;

        public Camera()
        {
            location = Vector3.Zero;
            rotation = Vector3.Zero;
        }
        public Matrix4 GetMatrix4()
        {
            return Matrix4.Identity * Matrix4.CreateTranslation(location) * Matrix4.CreateRotationX(rotation.X) * Matrix4.CreateRotationY(rotation.Y) * Matrix4.CreateRotationZ(rotation.Z);
        }
    }
}
