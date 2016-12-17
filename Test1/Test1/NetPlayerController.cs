using System;
using System.Collections.Generic;
using System.Text;
using OpenTK.Input;
using Test1.Net;
using Test1.Core;

namespace Test1
{
    class NetPlayerController
    {
        private readonly List<PlayerControlCommand> _commands = new List<PlayerControlCommand>();
        private StringBuilder _message;
        private readonly NetWorker _netWorker = Network.NetWorker;
        
        public NetPlayerController()
        {
            //_netWorker.Connect();
            var movingLeft = new PlayerControlCommand(new List<Key>(), new List<Action>());
            movingLeft.Keys.Add(Key.A);           
            movingLeft.Actions.Add(() => { _message.Append("mvl/"); });

            var movingRight = new PlayerControlCommand(new List<Key>(), new List<Action>());
            movingRight.Keys.Add(Key.D);
            movingRight.Actions.Add(() => { _message.Append("mvr/"); });

            var movingUp = new PlayerControlCommand(new List<Key>(), new List<Action>());
            movingUp.Keys.Add(Key.W);
            movingUp.Actions.Add(() => { _message.Append("mvu/"); });

            var movingDown = new PlayerControlCommand(new List<Key>(), new List<Action>());
            movingDown.Keys.Add(Key.S);
            movingDown.Actions.Add(() => { _message.Append("mvd/"); });

            var shootingLeft = new PlayerControlCommand(new List<Key>(), new List<Action>());
            shootingLeft.Keys.Add(Key.Left);
            shootingLeft.Actions.Add(() => { _message.Append("shl/"); });

            var shootingRight = new PlayerControlCommand(new List<Key>(), new List<Action>());
            shootingRight.Keys.Add(Key.Right);
            shootingRight.Actions.Add(() => { _message.Append("shr/"); });

            var shootingUp = new PlayerControlCommand(new List<Key>(), new List<Action>());
            shootingUp.Keys.Add(Key.Up);
            shootingUp.Actions.Add(() => { _message.Append("shu/"); });

            var shootingDown = new PlayerControlCommand(new List<Key>(), new List<Action>());
            shootingDown.Keys.Add(Key.Down);
            shootingDown.Actions.Add(() => { _message.Append("shd/"); });

            var turningLeverLeft = new PlayerControlCommand(new List<Key>(), new List<Action>());
            turningLeverLeft.Keys.Add(Key.Q);
            turningLeverLeft.Actions.Add(() => { _message.Append("tll/"); });

            var turningLeverRight = new PlayerControlCommand(new List<Key>(), new List<Action>());
            turningLeverRight.Keys.Add(Key.E);
            turningLeverRight.Actions.Add(() => { _message.Append("tlr/"); });

            _commands.Add(movingLeft);
            _commands.Add(movingRight);
            _commands.Add(movingUp);
            _commands.Add(movingDown);
            _commands.Add(shootingLeft);
            _commands.Add(shootingRight);
            _commands.Add(shootingUp);
            _commands.Add(shootingDown);
            _commands.Add(turningLeverLeft);
            _commands.Add(turningLeverRight);
        }

        public void Control()
        {
            _message = new StringBuilder();
            var state = OpenTK.Input.Keyboard.GetState();
            var allKeys = true;
            foreach (var t in _commands)
            {
                foreach (var key in t.Keys)
                {
                    if (!state[key])
                    {
                        allKeys = false;
                    }
                }
                if (allKeys)
                {
                    foreach (var act in t.Actions)
                    {
                        //Console.WriteLine(t.Keys[0]);
                        act.Invoke();
                    }
                }
                allKeys = true;
                
            }
            _netWorker.Send(Encoding.UTF8.GetBytes(_message.ToString()));
            //Console.WriteLine("Send message = {0}", _message);

        }
    }
}
