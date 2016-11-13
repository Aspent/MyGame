using OpenTK.Graphics.OpenGL;

namespace Test1
{
    class EnemyDrawer
    {
        #region Fields

        int[] _textures;

        #endregion

        #region Constructors

        public EnemyDrawer(int[] textures)
        {
            _textures = textures;
        }

        #endregion

        #region Methods

        public void Draw(Enemy enemy)
        {
            GL.BindTexture(TextureTarget.Texture2D, _textures[enemy.Texture]);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
            new RectangleDrawer().Draw(enemy.Form);
            GL.Disable(EnableCap.Blend);
        }

        #endregion
    }
}
