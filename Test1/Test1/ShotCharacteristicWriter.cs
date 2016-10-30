using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Test1
{
    class ShotCharacteristicWriter
    {
        #region Methods

        public void WriteInFile(string fileName, ShotCharacteristics shotChar)
        {
            using (var file = File.CreateText("Shots/" + fileName)) 
            {
                file.WriteLine(shotChar.Width);
                file.WriteLine(shotChar.Height);
                file.WriteLine(shotChar.LeftTexture);
                file.WriteLine(shotChar.RightTexture);
                file.WriteLine(shotChar.Name);
            }
        }

        #endregion
    }
}
