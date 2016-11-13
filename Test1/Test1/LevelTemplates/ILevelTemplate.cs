using System.Collections.Generic;

namespace Test1
{
    interface ILevelTemplate
    {
        Level GetLevel(List<string> itemNames, Dictionary<string, Item.ItemEffect> itemEffects,
            List<string> fileNames);   
    }
}
