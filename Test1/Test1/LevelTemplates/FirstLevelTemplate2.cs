using System;
using System.Collections.Generic;
using System.Drawing;

namespace Test1
{
    class FirstLevelTemplate2 : ILevelTemplate
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
            Room room7 = new Room(fileNames[random.Next(fileNames.Count)]);

            var room8 = new BossRoom(new RectangleF(-0.85f, 0.5f, 1.7f, -1.4f), 3,
                new Boss(0.15f, -0.25f, 0.3f, 0.2f, 0.2f / 60, 1200, 26, 27, new ShotCharacteristics("Fireball.f"),
                    20, 1, 0.22f / 60, 1.7f * 2 / 5, "Boss", Boss.ShootRound5));

            int[] trueState = new int[] { 0, 2, 2 };
            var note = new Note(new RectangleF(-0.3f, 0.0f, 0.2f, -0.2f), 75, 76, trueState);
            var room9 = new ChallengeRoom(new RectangleF(-0.85f, 0.5f, 1.7f, -1.4f), 2, note);

            room1.LeftDoor = new Door(room1, room2, "left");
            room2.RightDoor = new Door(room2, room1, "right");

            room1.BotDoor = new Door(room1, room6, "bot");
            room6.TopDoor = new Door(room6, room1, "top");
            room2.TopDoor = new Door(room2, room3, "top");
            room3.BotDoor = new Door(room3, room2, "bot");
            room3.TopDoor = new Door(room3, room4, "top");
            room4.BotDoor = new Door(room4, room3, "bot");

            room2.LeftDoor = new Door(room2, room5, "left");
            room5.RightDoor = new Door(room5, room2, "right");

            room5.BotDoor = new Door(room5, room9, "bot");
            room9.TopDoor = new Door(room9, room5, "top");

            room6.RightDoor = new Door(room6, room7, "right");
            room7.LeftDoor = new Door(room7, room6, "left");

            room7.BotDoor = new Door(room7, room8, "bot");
            room8.TopDoor = new Door(room8, room7, "top");

            room1.Enemies.Clear();
            int itemIndex = random.Next(itemNames.Count);
            room8.Items.Add(new Item(room8.Form.Left + 0.5f, room8.Form.Bottom + 0.5f,
                itemEffects[itemNames[itemIndex]], itemNames[itemIndex] + ".f"));
            itemNames.Remove(itemNames[itemIndex]);

            itemIndex = random.Next(itemNames.Count);
            room9.Items.Add(new Item(room9.Form.Left + 0.5f, room9.Form.Bottom + 0.5f,
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
            rooms.Add(room9);

            foreach (var t in rooms)
            {
                var n = random.Next(100);
                if (n <= 20)
                {
                    t.Items.Add(new Item(t.Form.Left + 0.7f, t.Form.Bottom + 0.7f,
                        ItemEffect.UpHealth, "Heart.f"));
                }

            }

            return new Level(rooms, room8, 0);
        }
    }
}
