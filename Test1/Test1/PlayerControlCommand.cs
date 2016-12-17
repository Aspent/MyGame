using System;
using System.Collections.Generic;
using OpenTK.Input;

namespace Test1
{
    class PlayerControlCommand
    {
        private readonly List<Key> _keys;
        private readonly List<Action> _actions;

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
