using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Input;

namespace Test1
{
    class PlayerControlCommand
    {
        private List<Key> _keys;
        private List<Action> _actions;

        public PlayerControlCommand(List<Key> keys, List<Action> actions)
        {
            _keys = keys;
            _actions = actions;
        }

        public List<Key> Keys
        {
            get { return _keys; }
        }

        public List<Action> Actions
        {
            get { return _actions; }
        }
    }
}
