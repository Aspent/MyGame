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
    class PlayerDrawer
    {
        #region Fields

        int[] _textures;

        #endregion

        #region Constructors

        public PlayerDrawer(int[] textures)
        {
            _textures = textures;
        }

        #endregion

        #region Methods

        public void Draw(Player player)
        {
            GL.BindTexture(TextureTarget.Texture2D, _textures[player.Texture]);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
            new RectangleDrawer().Draw(player.Form);
            GL.Disable(EnableCap.Blend);
        }

        #endregion
    }
}
