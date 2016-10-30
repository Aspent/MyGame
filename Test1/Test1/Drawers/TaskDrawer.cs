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
    class TaskDrawer
    {
        #region Fields

        int[] _textures;

        #endregion

        #region Constructors

        public TaskDrawer(int[] textures)
        {
            _textures = textures;
        }

        #endregion

        #region Methods

        public void Draw(Note note)
        {
            GL.BindTexture(TextureTarget.Texture2D, _textures[note.TaskTexture]);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
            new RectangleDrawer().Draw(new RectangleF(-0.3f, 0, 0.5f, -0.5f));
            GL.Disable(EnableCap.Blend);
        }

        #endregion
    }
}
