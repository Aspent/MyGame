using OpenTK.Graphics.OpenGL;

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
