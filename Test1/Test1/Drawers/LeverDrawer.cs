using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;

namespace Test1
{
    class LeverDrawer
    {
        #region Fields

        int[] _textures;

        #endregion

        #region Constructors

        public LeverDrawer(int[] textures)
        {
            _textures = textures;
        }

        #endregion

        #region Methods

        public void Draw(Lever lever)
        {
            GL.BindTexture(TextureTarget.Texture2D, _textures[lever.Textures[lever.CurrentState]]);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
            new RectangleDrawer().Draw(lever.Form);
            //GL.BindTexture(TextureTarget.Texture2D, _textures[3]);
            //new RectangleDrawer().Draw(lever.InteractionForm);
            GL.Disable(EnableCap.Blend);
        }

        #endregion
    }
}
