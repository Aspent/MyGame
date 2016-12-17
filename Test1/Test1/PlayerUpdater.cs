using System;
using Test1.Core;

namespace Test1
{
    class PlayerUpdater
    {
        public void Update(Player player)
        {
            var networker = Network.NetWorker;
            var posX =  BitConverter.ToSingle(networker.Receive(), 0);
            var posY =  BitConverter.ToSingle(networker.Receive(), 0);
            player.MoveTo(posX, posY);
            //Console.WriteLine("X = {0}, Y = {1}", posX, posY);
        }
    }
}
