using OpenTK.Graphics.OpenGL;

namespace Test1
{
    class FinishZoneDrawer
    {
        #region Fields

        int[] _textures;

        #endregion

        #region Constructors

        public FinishZoneDrawer(int[] textures)
        {
            _textures = textures;
        }

        #endregion

        #region Methods

        public void Draw(FinishZone finishZone)
        {
            GL.BindTexture(TextureTarget.Texture2D, _textures[finishZone.Texture]);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
            new RectangleDrawer().Draw(finishZone.Form);
            GL.Disable(EnableCap.Blend);
        }

        #endregion
    }
}
