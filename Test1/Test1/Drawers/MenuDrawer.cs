using OpenTK.Graphics.OpenGL;

namespace Test1
{
    class MenuDrawer
    {
         #region Fields

        int[] _textures;

        #endregion

        #region Constructors

        public MenuDrawer(int[] textures)
        {
            _textures = textures;
        }

        #endregion

        #region Methods

        public void Draw(Menu menu)
        {
            GL.BindTexture(TextureTarget.Texture2D, _textures[menu.Texture]);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
            new RectangleDrawer().Draw(menu.Form);
            GL.Disable(EnableCap.Blend);
            foreach (var t in menu.Buttons)
            {
                new ButtonDrawer(_textures).Draw(t);
            }
        }

        #endregion
    }
}
