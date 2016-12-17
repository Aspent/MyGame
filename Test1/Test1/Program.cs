using System.Windows.Forms;

namespace Test1
{

    class Program
    {
        static void Main(string[] args)
        {
            var resolution = SystemInformation.PrimaryMonitorSize;
            using (var game = new Game(resolution.Width, resolution.Height))
            {
                game.Run();
            }
            //var netWorker = new NetWorker();
            //netWorker.Connect();
            //var str = "I love you server!";
            //netWorker.Send(Encoding.UTF8.GetBytes(str));
        }
    }
}

//TODO: Добавить 2 игрока
