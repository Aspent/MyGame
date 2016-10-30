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
    class DoorDrawer
    {
        #region Fields

        int[] _textures;

        #endregion

        #region Constructors

        public DoorDrawer(int[] textures)
        {
            _textures = textures;
        }

        #endregion

        #region Methods

        public void Draw(Door door)
        {
            if (door.IsLocked)
            {
                GL.BindTexture(TextureTarget.Texture2D, _textures[door.ClosedTexture]);
            }
            else
            {
                GL.BindTexture(TextureTarget.Texture2D, _textures[door.Texture]);
            }
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
            GL.PushMatrix();
            
            new RectangleDrawer().Draw(door.Form);
            GL.PopMatrix();
            GL.Disable(EnableCap.Blend);
        }

        #endregion
    }
}
