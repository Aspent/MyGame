using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using System.Drawing.Imaging;

namespace Test1
{
    class ObstacleDrawer
    {
        #region Fields

        int[] _textures;

        #endregion

        #region Constructors

        public ObstacleDrawer(int[] textures)
        {
            _textures = textures;
        }

        #endregion

        #region Methods

        public void Draw(Room room, Obstacle obstacle)
        {
            GL.BindTexture(TextureTarget.Texture2D, _textures[obstacle.Texture]);

            new RectangleDrawer().Draw(obstacle.Form);
        }

        #endregion
    }
}
