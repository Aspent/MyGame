using OpenTK.Graphics.OpenGL;

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
