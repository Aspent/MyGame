using OpenTK.Graphics.OpenGL;

namespace Test1
{
    class ButtonDrawer
    {
        #region Fields

        int[] _textures;

        #endregion

        #region Constructors

        public ButtonDrawer(int[] textures)
        {
            _textures = textures;
        }

        #endregion

        #region Methods

        public void Draw(Button button)
        {
            GL.BindTexture(TextureTarget.Texture2D, _textures[button.Texture]);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
            new RectangleDrawer().Draw(button.Form);
            GL.Disable(EnableCap.Blend);
        }

        #endregion
    }
}
