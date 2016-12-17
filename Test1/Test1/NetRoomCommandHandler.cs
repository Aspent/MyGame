using System;
using System.Collections.Generic;
using System.Text;
using Test1.Core;

namespace Test1
{
    class NetRoomCommandHandler
    {
        private readonly Level _level;
        private readonly Dictionary<string, ActionOnLevel> _onLevelActions = new Dictionary<string,ActionOnLevel>(); 
        private readonly Dictionary<string, int> _parametersCount = new Dictionary<string, int>(); 

        private delegate void ActionOnLevel(Level level, string[] parametres);

        public NetRoomCommandHandler(Level level)
        {
            _level = level;
            _onLevelActions["enemy_add"] = (level1, parametres) =>
            {
                level1.CurrentRoom.Enemies.Add(new Enemy(float.Parse(parametres[0]), float.Parse(parametres[1]),
                     float.Parse(parametres[2]), float.Parse(parametres[3]), int.Parse(parametres[4])));
            };
            _parametersCount["enemy_add"] = 5;

            _onLevelActions["enemy_move"] = (level1, parametres) =>
            {
                var enemy = level1.CurrentRoom.Enemies[int.Parse(parametres[0])];
                enemy.MoveTo(float.Parse(parametres[1]), float.Parse(parametres[2]));
                enemy.Texture = int.Parse(parametres[3]);
            };
            _parametersCount["enemy_move"] = 4;

            _onLevelActions["enemy_remove"] = (level1, parametres) =>
            {
                var enemy = level1.CurrentRoom.Enemies[int.Parse(parametres[0])];
                level1.CurrentRoom.Enemies.Remove(enemy);
            };
            _parametersCount["enemy_remove"] = 1;

            _onLevelActions["shot_add"] = (level1, parametres) =>
            {
                level1.CurrentRoom.Shots.Add(new Shot(float.Parse(parametres[0]), float.Parse(parametres[1]),
                     float.Parse(parametres[2]), float.Parse(parametres[3]), int.Parse(parametres[4])));  
                //Console.WriteLine("shot was added");
                //Console.WriteLine(level1.CurrentRoom.Shots.Count);
            };
            _parametersCount["shot_add"] = 5;

            _onLevelActions["shot_move"] = (level1, parametres) =>
            {
                var shot = level1.CurrentRoom.Shots[int.Parse(parametres[0])];
                shot.MoveTo(float.Parse(parametres[1]), float.Parse(parametres[2]));
                shot.Texture = int.Parse(parametres[3]);
            };
            _parametersCount["shot_move"] = 4;

            _onLevelActions["shot_remove"] = (level1, parametres) =>
            {
                var shot = level1.CurrentRoom.Shots[int.Parse(parametres[0])];
                level1.CurrentRoom.Shots.Remove(shot);
            };
            _parametersCount["shot_remove"] = 1;

            _onLevelActions["player_add"] = (level1, parametres) =>
            {
                level1.CurrentRoom.Players.Add(new Player(float.Parse(parametres[0]), float.Parse(parametres[1]),
                     float.Parse(parametres[2]), float.Parse(parametres[3]), int.Parse(parametres[4])));
            };
            _parametersCount["player_add"] = 5;

            _onLevelActions["player_move"] = (level1, parametres) =>
            {
                var player = level1.CurrentRoom.Players[int.Parse(parametres[0])];
                player.MoveTo(float.Parse(parametres[1]), float.Parse(parametres[2]));
                player.Texture = int.Parse(parametres[3]);
            };
            _parametersCount["player_move"] = 4;

            _onLevelActions["player_remove"] = (level1, parametres) =>
            {
                var player = level1.CurrentRoom.Players[int.Parse(parametres[0])];
                level1.CurrentRoom.Players.Remove(player);
            };
            _parametersCount["player_remove"] = 1;
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
            for (var i = 0; i < commands.Length-1; i++)
            {
                var count = _parametersCount[commands[i]];
                var parameters = new string[count];
                for(var j=1; j<=count; j++)
                {
                    parameters[j-1] = commands[i + j];
                }
                _onLevelActions[commands[i]].Invoke(_level, parameters);

                i += count;
            }
        }
    }
}
