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
    class NoteDrawer
    {
         #region Fields

        int[] _textures;

        #endregion

        #region Constructors

        public NoteDrawer(int[] textures)
        {
            _textures = textures;
        }

        #endregion

        #region Methods

        public void Draw(Note note)
        {
            GL.BindTexture(TextureTarget.Texture2D, _textures[note.Texture]);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
            new RectangleDrawer().Draw(note.Form);
            GL.Disable(EnableCap.Blend);
        }

        #endregion
    }
}
