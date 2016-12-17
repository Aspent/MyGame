using OpenTK.Graphics.OpenGL;

namespace Test1
{
    class ObstacleDrawer
    {
        #region Fields

        readonly int[] _textures;

        #endregion

        #region Constructors

        public ObstacleDrawer(int[] textures)
        {
            _textures = textures;
        }

        #endregion

        #region Methods

        public void Draw(Room room, Obstacle obstacle)
        {
            GL.BindTexture(TextureTarget.Texture2D, _textures[obstacle.Texture]);

            new RectangleDrawer().Draw(obstacle.Form);
        }

        #endregion
    }
}
