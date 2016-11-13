using System.IO;

namespace Test1
{
    class ItemWriter
    {
        #region Methods

        public void WriteInFile(string fileName, Item item)
        {
            using (var file = File.CreateText("Items/" + fileName))
            {
                file.WriteLine(item.Form.Width);
                file.WriteLine(item.Form.Height);
                file.WriteLine(item.Texture);
                file.WriteLine(item.Name);
            }
        }

        #endregion
    }
}
