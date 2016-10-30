using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Test1
{
    class Note
    {
        #region Fields

        RectangleF _form;
        int _texture;
        int _taskTexture;
        int[] _trueState;

        #endregion

        #region Constructors

        public Note(RectangleF form, int texture, int taskTexture, int[] trueState)
        {
            _form = form;
            _texture = texture;
            _taskTexture = taskTexture;
            _trueState = trueState;
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

        public int TaskTexture
        {
            get { return _taskTexture; }
        }

        public int[] TrueState
        {
            get { return _trueState; }
        }

        #endregion


    }
}
