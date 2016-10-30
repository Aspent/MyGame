using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    interface ILevelTemplate
    {
        Level GetLevel(List<string> itemNames, Dictionary<string, Item.ItemEffect> itemEffects,
            List<string> fileNames);   
    }
}
