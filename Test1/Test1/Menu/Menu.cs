using System.Collections.Generic;
using System.Drawing;

namespace Test1
{
    class Menu
    {
        #region Fields

        RectangleF _form;
        int _texture;
        List<Button> _buttons = new List<Button>();

        #endregion

        #region Constructors

        public Menu(RectangleF form, int texture)
        {
            _form = form;
            _texture = texture;
        }

        #endregion

        #region Properties

        public RectangleF Form
        {
            get { return _form; }
        }

        public int Texture
        {
            get { return _texture; }
        }

        public List<Button> Buttons
        {
            get { return _buttons; }
        }

        #endregion

    }
}
