using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    class RoomBorder
    {
        #region Fields

        float _width;
        float _height;
        int _texture;

        #endregion

        #region Constructors

        public RoomBorder(float width, float height, int texture)
        {
            _width = width;
            _height = height;
            _texture = texture;
        }

        #endregion

        #region Properties

        public float Width
        {
            get { return _width; }
        }

        public float Height
        {
            get { return _height; }
        }

        public int Texture
        {
            get { return _texture; }
            set { _texture = value; }
        }

        #endregion
    }
}
