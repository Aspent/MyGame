using OpenTK.Graphics.OpenGL;

namespace Test1
{
    class RoomBorderDrawer
    {
        #region Fields

        int[] _textures;

        #endregion

        #region Constructors

        public RoomBorderDrawer(int[] textures)
        {
            _textures = textures;
        }

        #endregion

        #region Methods

        public void Draw(Room room, RoomBorder roomBorder)
        {
            GL.BindTexture(TextureTarget.Texture2D, _textures[roomBorder.Texture]);

            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0, 0);
            GL.Vertex2(room.Form.Left, room.Form.Top);
            GL.TexCoord2(0, 1);
            GL.Vertex2(room.Form.Left + roomBorder.Width, room.Form.Top - roomBorder.Height);
            GL.TexCoord2(1, 1);
            GL.Vertex2(room.Form.Right - roomBorder.Width, room.Form.Top - roomBorder.Height);
            GL.TexCoord2(1, 0);
            GL.Vertex2(room.Form.Right, room.Form.Top);
            GL.End();

            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0, 1);
            GL.Vertex2(room.Form.Right - roomBorder.Width, room.Form.Top - roomBorder.Height);
            GL.TexCoord2(1, 1);
            GL.Vertex2(room.Form.Right - roomBorder.Width, room.Form.Bottom + roomBorder.Height);
            GL.TexCoord2(1, 0);
            GL.Vertex2(room.Form.Right, room.Form.Bottom);
            GL.TexCoord2(0, 0);
            GL.Vertex2(room.Form.Right, room.Form.Top);
            GL.End();

            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0, 0);
            GL.Vertex2(room.Form.Right, room.Form.Bottom);
            GL.TexCoord2(0, 1);
            GL.Vertex2(room.Form.Right - roomBorder.Width, room.Form.Bottom + roomBorder.Height);
            GL.TexCoord2(1, 1);
            GL.Vertex2(room.Form.Left + roomBorder.Width, room.Form.Bottom + roomBorder.Height);
            GL.TexCoord2(1, 0);
            GL.Vertex2(room.Form.Left, room.Form.Bottom);
            GL.End();

            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0, 0);
            GL.Vertex2(room.Form.Left, room.Form.Bottom);
            GL.TexCoord2(0, 1);
            GL.Vertex2(room.Form.Left + roomBorder.Width, room.Form.Bottom + roomBorder.Height);
            GL.TexCoord2(1, 1);
            GL.Vertex2(room.Form.Left + roomBorder.Width, room.Form.Top - roomBorder.Height);
            GL.TexCoord2(1, 0);
            GL.Vertex2(room.Form.Left, room.Form.Top);
            GL.End();

            
        }

        #endregion
    }
}
