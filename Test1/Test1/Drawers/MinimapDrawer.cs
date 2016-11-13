using OpenTK.Graphics.OpenGL;
using System.Drawing;
using Test1.Core;

namespace Test1
{
    class MinimapDrawer
    {
        #region Fields

        int[] _textures;
        //Game _game;
        float _rectSide = 0.05f;
        float _linkWidth = 0.012f;
        float _linkHeight = 0.02f;

        #endregion

        #region Constructors

        public MinimapDrawer(int[] textures)
        {
            _textures = textures;
            //_game = game;
        }

        #endregion

        #region Methods

        public void Draw(Room currentRoom)
        {
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
            GL.PushMatrix();
            var w = GameInfo.Width;
            var h = GameInfo.Height;
            var ratio = 1.0f * w / h;

            GL.BindTexture(TextureTarget.Texture2D, _textures[88]);

            DrawAllNeighbourRooms(currentRoom, ratio - 0.5f + 0.2f,
                   1 - 0.4f + 0.2f);
            if(currentRoom.TopDoor != null)
            {
                DrawAllNeighbourRooms(currentRoom.TopDoor.NextRoom, ratio - 0.5f + 0.2f,
                    1 - 0.4f + 0.2f + 0.07f);
            }
            if (currentRoom.BotDoor != null)
            {
                DrawAllNeighbourRooms(currentRoom.BotDoor.NextRoom, ratio - 0.5f + 0.2f,
                    1 - 0.4f + 0.2f - 0.07f);
            }
            if (currentRoom.LeftDoor != null)
            {
                DrawAllNeighbourRooms(currentRoom.LeftDoor.NextRoom, ratio - 0.5f + 0.2f - 0.07f,
                    1 - 0.4f + 0.2f);
            }
            if (currentRoom.RightDoor != null)
            {
                DrawAllNeighbourRooms(currentRoom.RightDoor.NextRoom, ratio - 0.5f + 0.2f + 0.07f,
                    1 - 0.4f + 0.2f);
            }
            GL.BindTexture(TextureTarget.Texture2D, _textures[89]);
            new RectangleDrawer().Draw(new RectangleF(ratio - 0.5f + 0.2f - _rectSide / 2, 
                1 - 0.4f + 0.2f - _rectSide/2,
                    _rectSide, _rectSide));
            

            GL.PopMatrix();
            GL.Disable(EnableCap.Blend);
        }

        private void DrawAllNeighbourRooms(Room room, float x, float y)
        {

            if(room.TopDoor != null)
            {
                new RectangleDrawer().Draw(new RectangleF(x - _rectSide/2, y + _rectSide/2 + _linkHeight, 
                    _rectSide, _rectSide ));
                new RectangleDrawer().Draw(new RectangleF(x - _linkWidth / 2, y + _rectSide/2,
                    _linkWidth, _linkHeight));  
            }
            if (room.BotDoor != null)
            {
                new RectangleDrawer().Draw(new RectangleF(x - _rectSide / 2, y - _rectSide*3 / 2 - _linkHeight,
                    _rectSide, _rectSide));
                new RectangleDrawer().Draw(new RectangleF(x - _linkWidth / 2, y - _rectSide / 2,
                    _linkWidth, -_linkHeight));  
            }
            if (room.LeftDoor != null)
            {
                new RectangleDrawer().Draw(new RectangleF(x - _rectSide / 2 - _linkHeight, y - _rectSide / 2,
                    -_rectSide, _rectSide));
                new RectangleDrawer().Draw(new RectangleF(x - _rectSide / 2, y - _linkWidth / 2,
                    -_linkHeight, _linkWidth));
            }
            if (room.RightDoor != null)
            {
                new RectangleDrawer().Draw(new RectangleF(x + _rectSide / 2 + _linkHeight, y - _rectSide / 2,
                   _rectSide, _rectSide));
                new RectangleDrawer().Draw(new RectangleF(x + _rectSide / 2 , y - _linkWidth / 2,
                    _linkHeight, _linkWidth));
            }

        }

        #endregion
    }
}
