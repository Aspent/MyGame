using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System.Drawing;

namespace Test1
{
    class PlayerStatsDrawer
    {
        #region Fields

        int[] _textures;
        Game _game;

        #endregion

        #region Constructors

        public PlayerStatsDrawer(int[] textures, Game game)
        {
            _textures = textures;
            _game = game;
        }

        #endregion

        #region Methods

        public void Draw(Player player)
        {
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
            GL.PushMatrix();
            var w = _game.Width;
            var h = _game.Height;
            var ratio = 1.0f * w / h;

            for (var i = 0; i < player.MaxHp; i++)
            {
                if(i < player.Hp)
                {
                    GL.BindTexture(TextureTarget.Texture2D, _textures[25]);
                }
                else
                {
                    GL.BindTexture(TextureTarget.Texture2D, _textures[81]);
                }
                new RectangleDrawer().Draw(new RectangleF(-ratio + 2 * i * 0.05f + 0.05f, 1 - 0.05f, 0.05f, -0.05f));
            }

            GL.BindTexture(TextureTarget.Texture2D, _textures[78]);
            new RectangleDrawer().Draw(new RectangleF(-ratio, 1 - 0.15f, 0.15f, -0.05f));
            GL.BindTexture(TextureTarget.Texture2D, _textures[24]);
            for (var i = 1; i <= player.Damage; i++ )
            {
                new RectangleDrawer().Draw(new RectangleF(-ratio + 2 * i * 0.05f + 0.1f, 1 - 0.15f, 0.05f, -0.05f));
            }

            GL.BindTexture(TextureTarget.Texture2D, _textures[79]);
            new RectangleDrawer().Draw(new RectangleF(-ratio , 1 - 0.25f, 0.15f, -0.05f));
            GL.BindTexture(TextureTarget.Texture2D, _textures[9]);
            for (var i = 1; i <= player.Speed*10*60; i++)
            {
                new RectangleDrawer().Draw(new RectangleF(-ratio + 2 * i * 0.05f + 0.1f, 1 - 0.25f, 0.05f, -0.05f));
            }

            GL.BindTexture(TextureTarget.Texture2D, _textures[80]);
            new RectangleDrawer().Draw(new RectangleF(-ratio, 1 - 0.35f, 0.15f, -0.05f));
            GL.BindTexture(TextureTarget.Texture2D, _textures[20]);
            for (var i = 1; i <= player.ShotRange*5; i++)
            {
                new RectangleDrawer().Draw(new RectangleF(-ratio + 2 * i * 0.05f + 0.1f, 1 - 0.35f, 0.05f, -0.05f));
            }

            GL.PopMatrix();
            GL.Disable(EnableCap.Blend);
        }

        #endregion
    }
}
