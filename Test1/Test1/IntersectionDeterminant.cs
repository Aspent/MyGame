using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Test1
{
    class IntersectionDeterminant
    {
        #region Methods

        public bool IsIntersected(RectangleF firstRect, RectangleF secondRect)
        {
            if(firstRect.Right < secondRect.Left)
            {
                return false;
            }
            if (secondRect.Right < firstRect.Left)
            {
                return false;
            }
            if (firstRect.Bottom > secondRect.Top)
            {
                return false;
            }
            if (secondRect.Bottom > firstRect.Top)
            {
                return false;
            }
            return true;
        }
      
        #endregion
    }
}
