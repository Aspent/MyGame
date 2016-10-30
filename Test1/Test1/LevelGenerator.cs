using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    class LevelGenerator
    {
        #region Fields

        Random _rand = new Random();
        List<ILevelTemplate> _levelTemplates;

        #endregion

        #region Constructors

        public LevelGenerator(List<ILevelTemplate> levelTemplates)
        {
            _levelTemplates = levelTemplates;
        }

        #endregion

        #region Methods

        public Level Generate(List<string> itemNames, Dictionary<string, Item.ItemEffect> itemEffects,
            List<string> fileNames)
        {            
            return _levelTemplates[_rand.Next(_levelTemplates.Count)].GetLevel(itemNames, itemEffects, fileNames);
        }

        #endregion
    }
}
