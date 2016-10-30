using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Test1
{
    class RectangleDrawer
    {
        public void Draw(RectangleF rectangle)
        {
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0, 0);
            GL.Vertex2(rectangle.Left, rectangle.Top);
            GL.TexCoord2(1, 0);
            GL.Vertex2(rectangle.Right, rectangle.Top);
            GL.TexCoord2(1, 1);
            GL.Vertex2(rectangle.Right, rectangle.Bottom);
            GL.TexCoord2(0, 1);
            GL.Vertex2(rectangle.Left, rectangle.Bottom);
            GL.End();
        }
    }
}
