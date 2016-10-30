using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using System.Drawing.Imaging;

namespace Test1
{
    class RoomDrawer
    {
        #region Fields

        int[] _textures;

        #endregion

        #region Constructors

        public RoomDrawer(int[] textures)
        {
            _textures = textures;
        }

        #endregion

        #region Methods    

        public void Draw(Room room)
        {
            
            GL.BindTexture(TextureTarget.Texture2D, _textures[room.Texture]);            

            new RectangleDrawer().Draw(room.Form);

            var borderDrawer = new RoomBorderDrawer(_textures);
            borderDrawer.Draw(room, room.Border);

            foreach(var t in room.Obstacles)
            {
                var obsDrawer = new ObstacleDrawer(_textures);
                obsDrawer.Draw(room, t);
            }

            foreach (var t in room.Enemies)
            {
                var enemyDrawer = new EnemyDrawer(_textures);
                enemyDrawer.Draw(t);
            }

            foreach (var t in room.Shots)
            {
                var shotDrawer = new ShotDrawer(_textures);
                shotDrawer.Draw(t);
            }

            if (room is BossRoom)
            {
                var bRoom = room as BossRoom;
                var finishZoneDrawer = new FinishZoneDrawer(_textures);
                if (bRoom.FinishZone.IsActive)
                {
                    finishZoneDrawer.Draw(bRoom.FinishZone);
                }
                
            }

            foreach (var t in room.Items)
            {
                if (t.IsAvailable)
                {
                    var itemDrawer = new ItemDrawer(_textures);
                    itemDrawer.Draw(t);
                }
            }

            var doorDrawer = new DoorDrawer(_textures);

            if(room.TopDoor != null)
            {
                doorDrawer.Draw(room.TopDoor);
            }
            if (room.BotDoor != null)
            {
                doorDrawer.Draw(room.BotDoor);
            }
            if (room.LeftDoor != null)
            {
                doorDrawer.Draw(room.LeftDoor);
            }
            if (room.RightDoor != null)
            {
                doorDrawer.Draw(room.RightDoor);
            }

        }

        public void Draw(ChallengeRoom room)
        {
            GL.BindTexture(TextureTarget.Texture2D, _textures[room.Texture]);

            new RectangleDrawer().Draw(room.Form);

            var borderDrawer = new RoomBorderDrawer(_textures);
            borderDrawer.Draw(room, room.Border);

            var leverDrawer = new LeverDrawer(_textures);
            foreach (var t in room.Levers)
            {
                leverDrawer.Draw(t);
            }

            foreach (var t in room.Shots)
            {
                var shotDrawer = new ShotDrawer(_textures);
                shotDrawer.Draw(t);
            }

            foreach (var t in room.Items)
            {
                if (t.IsAvailable)
                {
                    var itemDrawer = new ItemDrawer(_textures);
                    itemDrawer.Draw(t);
                }
            }

            new NoteDrawer(_textures).Draw(room.Note);

            var doorDrawer = new DoorDrawer(_textures);

            if (room.TopDoor != null)
            {
                doorDrawer.Draw(room.TopDoor);
            }
            if (room.BotDoor != null)
            {
                doorDrawer.Draw(room.BotDoor);
            }
            if (room.LeftDoor != null)
            {
                doorDrawer.Draw(room.LeftDoor);
            }
            if (room.RightDoor != null)
            {
                doorDrawer.Draw(room.RightDoor);
            }

        }

        #endregion
    }
}
