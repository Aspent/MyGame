using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace Test1
{
    class Command
    {
        public delegate void PlayerAction(Player player, Room room);

        #region Fields

        List<Key> _keys;
        List<PlayerAction> _actions;

        #endregion

        #region Constructors

        public Command(List<Key> keys, List<PlayerAction> actions)
        {
            _keys = keys;
            _actions = actions;            
        }

        #endregion

        #region Properties

        public List<Key> Keys
        {
            get { return _keys; }
        }

        public List<PlayerAction> Actions
        {
            get { return _actions; }
        }

        #endregion
    }
}
