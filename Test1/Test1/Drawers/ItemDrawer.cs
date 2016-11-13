using OpenTK.Graphics.OpenGL;

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
