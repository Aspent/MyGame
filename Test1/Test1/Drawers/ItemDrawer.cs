using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System.Drawing;

namespace Test1
{
    class ItemDrawer
    {
        #region Fields

        int[] _textures;

        #endregion

        #region Constructors

        public ItemDrawer(int[] textures)
        {
            _textures = textures;
        }

        #endregion

        #region Methods

        public void Draw(Item item)
        {
            GL.BindTexture(TextureTarget.Texture2D, _textures[item.Texture]);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
            new RectangleDrawer().Draw(item.Form);
            GL.Disable(EnableCap.Blend);
        }

        #endregion
    }
}
