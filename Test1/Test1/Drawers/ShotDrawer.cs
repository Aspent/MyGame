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
    class ShotDrawer
    {
         #region Fields

        int[] _textures;

        #endregion

        #region Constructors

        public ShotDrawer(int[] textures)
        {
            _textures = textures;
        }

        #endregion

        #region Methods

        public void Draw(Shot shot)
        {
            GL.BindTexture(TextureTarget.Texture2D, _textures[shot.Texture]);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
            new RectangleDrawer().Draw(shot.Form);
            GL.Disable(EnableCap.Blend);
        }

        #endregion
    }
}
