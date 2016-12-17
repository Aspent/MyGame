namespace Test1.Core
{
    class LevelDrawer
    {
        private readonly Level _level;
        private readonly Player _player;
        private readonly int[] _textures;
        //private Room _currentRoom;

        public LevelDrawer(Level level, int[] textures)
        {
            _level = level;
            _textures = textures;
            //_currentRoom = _level.Rooms[_level.CurrentRoomIndex];
            _player = _level.CurrentRoom.Player;
        }


        public void Draw()
        {
            if (_level.CurrentRoom is ChallengeRoom)
            {
                var chalRoom = _level.CurrentRoom as ChallengeRoom;
                new RoomDrawer(_textures).Draw(chalRoom);
            }
            else
            {
                new RoomDrawer(_textures).Draw(_level.CurrentRoom);
            }

            //new PlayerDrawer(_textures).Draw(_player);
            new PlayerStatsDrawer(_textures).Draw(_player);
            new  MinimapDrawer(_textures).Draw(_level.CurrentRoom);
            //_player.Controller.Control(_player, _currentRoom);
        }
    }
}
