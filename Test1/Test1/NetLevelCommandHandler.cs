﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test1.Core;

namespace Test1
{
    class NetLevelCommandHandler
    {
        private Level _level;
        private Dictionary<string, ActionOnLevel> _onLevelActions = new Dictionary<string, ActionOnLevel>();
        private Dictionary<string, int> _parametersCount = new Dictionary<string, int>();

        private delegate void ActionOnLevel(Level level, string[] parametres);

        public NetLevelCommandHandler(Level level)
        {
            _level = level;
            _onLevelActions["change_room"] = (level1, parametres) =>
            {
                //level1.CurrentRoom.Enemies.Add(new Enemy(float.Parse(parametres[0]), float.Parse(parametres[1]),
                //    int.Parse(parametres[2])));
                var player = level1.CurrentRoom.Player;
                level1.CurrentRoom = level1.Rooms[int.Parse(parametres[0])];
                level1.CurrentRoom.Player = player;
            };
            _parametersCount["change_room"] = 1;

         
        }



        public void Run()
        {
            var command = Encoding.UTF8.GetString(Network.NetWorker.Receive());

            if (command == null || command == "")
            {
                return;
            }
            Console.WriteLine(command);
            var commands = command.Split('/');
            for (var i = 0; i < commands.Length - 1; i++)
            {
                var count = _parametersCount[commands[i]];
                var parameters = new string[count];
                for (var j = 1; j <= count; j++)
                {
                    parameters[j - 1] = commands[i + j];
                }
                _onLevelActions[commands[i]].Invoke(_level, parameters);

                i += count;
            }
        }
    }
}
