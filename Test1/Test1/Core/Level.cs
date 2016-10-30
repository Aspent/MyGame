using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Test1
{
    class Level
    {
        #region Fields

        List<Room> _rooms;
        int _startRoomIndex;
        BossRoom _bossRoom;
        
        #endregion

        #region Constructors

        public Level()
        {
            _startRoomIndex = 0;
            _rooms = new List<Room>();
            var room1 = new Room("Room1.f");
            var room2 = new Room("Room2.f");
            var room3 = new Room("Room1.f");
            var room4 = new Room("Room2.f");
            var room5 = new Room("Room1.f");
            var room6 = new Room("Room2.f");

            var room7 = new BossRoom(new RectangleF(-0.85f, 0.5f, 1.7f, -1.4f), 3,
                new Boss(0.15f, -0.25f, 0.3f, 0.2f, 0.2f / 60, 1200, 7, 16, new ShotCharacteristics("Fireball.f"),
                    30, 4, 0.22f / 60, 1, "Boss", Boss.ShootRound10));

            int[] trueState = new int[] {0, 2, 2};
            var note = new Note(new RectangleF(0.5f, 0.5f, 0.2f, 0.2f), 0, 1, trueState);
            var room8 = new ChallengeRoom(new RectangleF(-0.85f, 0.5f, 1.7f, -1.4f), 1, note);

            room1.TopDoor = new Door(room1, room2, "top");
            room2.BotDoor = new Door(room2, room1, "bot");
            room2.RightDoor = new Door(room2, room3, "right");
            room3.LeftDoor = new Door(room3, room2, "left");
            room3.RightDoor = new Door(room3, room4, "right");
            room4.TopDoor = new Door(room4, room5, "top");
            room4.LeftDoor = new Door(room4, room3, "left");
            room4.BotDoor = new Door(room4, room6, "bot");
            room5.BotDoor = new Door(room5, room4, "bot");
            room6.TopDoor = new Door(room6, room4, "top");
            room6.BotDoor = new Door(room6, room7, "bot");
            room7.TopDoor = new Door(room7, room6, "top");
            room7.Items.Add(new Item(room7.Form.Left + 0.5f, room7.Form.Bottom + 0.5f,
                ItemEffect.UpSpeed, "Boot.f"));
            _bossRoom = room7;
            room5.TopDoor = new Door(room5, room8, "top");
            room8.BotDoor = new Door(room8, room5, "bot");

            _rooms.Add(room1);
            _rooms.Add(room2);
            _rooms.Add(room3);
            _rooms.Add(room4);
            _rooms.Add(room5);
            _rooms.Add(room6);

        }

        public Level(List<Room> rooms, BossRoom bossRoom, int startRoomIndex)
        {
            _rooms = rooms;
            _startRoomIndex = startRoomIndex;
            _bossRoom = bossRoom;
        }

        #endregion

        #region Properties

        public List<Room> Rooms
        {
            get { return _rooms; }
        }

        public int StartRoomIndex
        {
            get { return _startRoomIndex; }
        }

        public BossRoom BossRoom
        {
            get { return _bossRoom; }
        }


        #endregion
    }
}
