using System;
using System.Collections.Generic;
using System.Drawing;

namespace Test1
{
    class FirstLevelTemplate : ILevelTemplate
    {
        static Random random = new Random();

        public Level GetLevel(List<string> itemNames, Dictionary<string, Item.ItemEffect> itemEffects,
            List<string> fileNames)
        {
            var rooms = new List<Room>();

            Room room1 = new Room(fileNames[random.Next(fileNames.Count)]);
            Room room2 = new Room(fileNames[random.Next(fileNames.Count)]);
            Room room3 = new Room(fileNames[random.Next(fileNames.Count)]);
            Room room4 = new Room(fileNames[random.Next(fileNames.Count)]);
            Room room5 = new Room(fileNames[random.Next(fileNames.Count)]);
            Room room6 = new Room(fileNames[random.Next(fileNames.Count)]);

            var room7 = new BossRoom(new RectangleF(-0.85f, 0.5f, 1.7f, -1.4f), 3,
                new Boss(0.15f, -0.25f, 0.3f, 0.2f, 0.2f / 60, 1200, 26, 27, new ShotCharacteristics("Fireball.f"),
                    20, 1, 0.22f / 60, 1.7f * 2 / 5, "Boss", Boss.ShootRound5));

            int[] trueState = new int[] { 0, 2, 2 };
            var note = new Note(new RectangleF(-0.3f, 0.0f, 0.2f, -0.2f), 75, 76, trueState);
            var room8 = new ChallengeRoom(new RectangleF(-0.85f, 0.5f, 1.7f, -1.4f), 2, note);

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
            room5.TopDoor = new Door(room5, room8, "top");
            room8.BotDoor = new Door(room8, room5, "bot");

            room1.Enemies.Clear();
            int itemIndex = random.Next(itemNames.Count);
            room7.Items.Add(new Item(room7.Form.Left + 0.5f, room7.Form.Bottom + 0.5f,
                itemEffects[itemNames[itemIndex]], itemNames[itemIndex] + ".f"));
            itemNames.Remove(itemNames[itemIndex]);

            itemIndex = random.Next(itemNames.Count);
            room8.Items.Add(new Item(room8.Form.Left + 0.5f, room8.Form.Bottom + 0.5f,
                itemEffects[itemNames[itemIndex]], itemNames[itemIndex] + ".f"));
            itemNames.Remove(itemNames[itemIndex]);

            rooms.Add(room1);
            rooms.Add(room2);
            rooms.Add(room3);
            rooms.Add(room4);
            rooms.Add(room5);
            rooms.Add(room6);
            rooms.Add(room7);
            rooms.Add(room8);

            foreach(var t in rooms)
            {
                var n = random.Next(100);
                if(n <= 20)
                {
                    t.Items.Add(new Item(t.Form.Left + 0.7f, t.Form.Bottom + 0.7f,
                        ItemEffect.UpHealth, "Heart.f"));
                }
                    
            }

            //room1.Enemies.Add(new Enemy(room1.Form.Left + 0.5f, room1.Form.Bottom + 0.5f, 400.0f / 1500,
            //    266.0f / 1500, 0.1f / 60, 1200, 51, 52, new ShotCharacteristics("Mel.f"), 14, 3, 0.18f / 60, room1.Form.Width,
            //    "Blackboard"));

            //room1.Enemies.Add(new Enemy(room1.Form.Left + 0.5f, room1.Form.Bottom + 0.5f, 400.0f / 1750,
            //    380.0f / 1750, 0.3f / 60, 800, 53, 54, new ShotCharacteristics("Book.f"), 14, 2, 0.18f / 60, room1.Form.Width * 4 / 5,
            //    "Bag"));

            //room1.Enemies.Add(new Enemy(room1.Form.Left + 0.15f,
            //    room1.Form.Bottom + 0.18f + 0.15f, "Blackboard.f"));

            //room1.Enemies.Add(new Enemy(room1.Form.Left + 0.15f,
            //    room1.Form.Top - 0.15f, "Bag.f"));

            //room1.Enemies.Add(new Enemy(room1.Form.Left + 0.15f,
            //    room1.Form.Top - 0.15f, "Ghost.f"));

            return new Level(rooms, room7, 0);
        }
    }
}
