using System;
using System.Collections.Generic;
using System.Drawing;

namespace Test1
{
    class ThirdLevelTemplate : ILevelTemplate
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


            var room5 = new BossRoom(new RectangleF(-0.85f, 0.5f, 1.7f, -1.4f), 58,
                new Boss(0.15f, -0.25f, 296.0f / 1500, 458.0f / 1500, 0.2f / 60, 1200, 55, 56, new ShotCharacteristics("Book.f"),
                    26, 3, 0.35f / 60, 1.7f*4/5, "Boss", Boss.SummonUp));
            room5.Border.Texture = 59;

            int[] trueState = new int[] { 0, 2, 2 };
            var note = new Note(new RectangleF(-0.3f, 0.0f, 0.2f, -0.2f), 75, 76, trueState);
            var room6 = new ChallengeRoom(new RectangleF(-0.85f, 0.5f, 1.7f, -1.4f), 2, note);
            room6.Border.Texture = 59;

            room1.RightDoor = new Door(room1, room2, "right");
            room2.LeftDoor = new Door(room2, room1, "left");

            room2.RightDoor = new Door(room2, room3, "right");
            room3.LeftDoor = new Door(room3, room2, "left");

            room3.BotDoor = new Door(room3, room4, "bot");
            room4.TopDoor = new Door(room4, room3, "top");

            room3.TopDoor = new Door(room3, room6, "top");
            room6.BotDoor = new Door(room6, room3, "bot");

            room4.RightDoor = new Door(room4, room5, "right");
            room5.LeftDoor = new Door(room5, room4, "left");

            room1.Enemies.Clear();
            int itemIndex = random.Next(itemNames.Count);
            room5.Items.Add(new Item(room5.Form.Left + 0.5f, room5.Form.Bottom + 0.5f,
                itemEffects[itemNames[itemIndex]], itemNames[itemIndex] + ".f"));
            itemNames.Remove(itemNames[itemIndex]);

            itemIndex = random.Next(itemNames.Count);
            room6.Items.Add(new Item(room6.Form.Left + 0.5f, room6.Form.Bottom + 0.5f,
            itemEffects[itemNames[itemIndex]], itemNames[itemIndex] + ".f"));
            itemNames.Remove(itemNames[itemIndex]);

            rooms.Add(room1);
            rooms.Add(room2);
            rooms.Add(room3);
            rooms.Add(room4);
            rooms.Add(room5);
            rooms.Add(room6);


            foreach (var t in rooms)
            {
                var n = random.Next(100);
                if (n <= 20)
                {
                    t.Items.Add(new Item(t.Form.Left + 0.7f, t.Form.Bottom + 0.7f,
                        ItemEffect.UpHealth, "Heart.f"));
                }
            }

            return new Level(rooms, room5, 0);
        }
    }
}
