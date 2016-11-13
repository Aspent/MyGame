namespace Test1
{
    class LevelSupervisor: ILevelSupervisor
    {
        #region Fields

        Game _game;
        Room _currentRoom;
        Player _player;
        RoomSupervisor _roomSupervisor;
        int[] _textures;
        //private Level _level;
        

        #endregion

        #region Constructors

        public LevelSupervisor(Game game)
        {
            _game = game;
            _player = game.Player;
            _currentRoom = game.CurrentRoom;
            _roomSupervisor = new RoomSupervisor(game);
            _textures = game.Textures;
        }

        #endregion

        #region Methods

        public void Run()
        {
            if (_currentRoom is ChallengeRoom)
            {
                var chalRoom = _currentRoom as ChallengeRoom;
                new RoomDrawer(_textures).Draw(chalRoom);
            }
            else
            {
                new RoomDrawer(_textures).Draw(_currentRoom);
            }

            new PlayerDrawer(_textures).Draw(_player);
            new PlayerStatsDrawer(_textures).Draw(_player);
            new MinimapDrawer(_textures).Draw(_currentRoom);
            _player.Controller.Control(_player, _currentRoom);

            _roomSupervisor.Run(_player, _currentRoom);
            var collisionChecker = new CollisionChecker();
            if (_currentRoom.Enemies.Count == 0 && !(_currentRoom is ChallengeRoom))
            {
                foreach (var t in _currentRoom.Items)
                {
                    if (!collisionChecker.IsCollided(_player, t))
                    {
                        t.IsAvailable = true;
                    }
                }
                var doors = _currentRoom.GetAllDoors();
                foreach (var t in doors)
                {
                    t.IsLocked = false;
                }
                if (_currentRoom is BossRoom)
                {
                    var bRoom = _currentRoom as BossRoom;
                    if (!collisionChecker.IsCollided(_player, bRoom.FinishZone))
                    {
                        bRoom.FinishZone.IsActive = true;
                    }
                }
            }
            if(_currentRoom is ChallengeRoom)
            {
                var isTrueState = true;
                var chalRoom = _currentRoom as ChallengeRoom;
                for (var i = 0; i < chalRoom.Levers.Count; i++)
                {
                    if(chalRoom.Levers[i].CurrentState != chalRoom.Note.TrueState[i])
                    {
                        isTrueState = false;
                    }
                }
                if(isTrueState)
                {
                    foreach (var t in _currentRoom.Items)
                    {
                        if (!collisionChecker.IsCollided(_player, t))
                        {
                            t.IsAvailable = true;
                        }
                    }
                    var doors = _currentRoom.GetAllDoors();
                    foreach (var t in doors)
                    {
                        t.IsLocked = false;
                    }
                }
            }

            if ((_currentRoom.TopDoor != null) && (collisionChecker.IsCollided(_player, _currentRoom.TopDoor)))
            {
                if (!_currentRoom.TopDoor.IsLocked)
                {
                    _currentRoom.Shots.Clear();
                    _currentRoom = _currentRoom.TopDoor.NextRoom;
                    _currentRoom.Player = _game.Player;
                    _player.MoveTo(_currentRoom.BotDoor.Form.Left, _currentRoom.BotDoor.Form.Top + 0.25f);
                    foreach(var t in _currentRoom.Enemies)
                    {
                        t.Timer.Start();
                    }
                }
            }
            if ((_currentRoom.BotDoor != null) && (collisionChecker.IsCollided(_player, _currentRoom.BotDoor)))
            {
                if (!_currentRoom.BotDoor.IsLocked)
                {
                    _currentRoom.Shots.Clear();
                    _currentRoom = _currentRoom.BotDoor.NextRoom;
                    _currentRoom.Player = _game.Player;
                    _player.MoveTo(_currentRoom.TopDoor.Form.Left, _currentRoom.TopDoor.Form.Bottom);
                    foreach (var t in _currentRoom.Enemies)
                    {
                        t.Timer.Start();
                    }
                }
            }
            if ((_currentRoom.LeftDoor != null) && (collisionChecker.IsCollided(_player, _currentRoom.LeftDoor)))
            {
                if (!_currentRoom.LeftDoor.IsLocked)
                {
                    _currentRoom.Shots.Clear();
                    _currentRoom = _currentRoom.LeftDoor.NextRoom;
                    _currentRoom.Player = _game.Player;
                    _player.MoveTo(_currentRoom.RightDoor.Form.Left - _player.Form.Width - 0.005f, _currentRoom.RightDoor.Form.Top);
                    foreach (var t in _currentRoom.Enemies)
                    {
                        t.Timer.Start();
                    }
                }
            }
            if ((_currentRoom.RightDoor != null) && (collisionChecker.IsCollided(_player, _currentRoom.RightDoor)))
            {
                if (!_currentRoom.RightDoor.IsLocked)
                {
                    _currentRoom.Shots.Clear();
                    _currentRoom = _currentRoom.RightDoor.NextRoom;
                    _currentRoom.Player = _game.Player;
                    _player.MoveTo(_currentRoom.LeftDoor.Form.Right, _currentRoom.LeftDoor.Form.Top);
                    foreach (var t in _currentRoom.Enemies)
                    {
                        t.Timer.Start();
                    }
                }
            }
            
        }

        #endregion

        
    }
}
