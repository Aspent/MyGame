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
        }
    }
}
//TODO: Добавить контроллеры игроков и врагов
//TODO: Исправить обработку комнат
//TODO: Добавить 2 игрока
