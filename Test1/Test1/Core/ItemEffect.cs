using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    class ItemEffect
    {
        #region Methods

        public static void UpMaxHealth(Player player, Game game)
        {
            player.UpMaxHealth();
        }

        public static void UpHealth(Player player, Game game)
        {
            player.UpHealth();
        }

        public static void UpSpeed(Player player, Game game)
        {
            player.UpSpeed();
        }

        public static void UpDamage(Player player, Game game)
        {
            player.UpDamage();
        }

        public static void UpRange(Player player, Game game)
        {
            player.UpRange();
        }

        public static void UpAttackSpeed(Player player, Game game)
        {
            player.UpAttackSpeed();
        }

        #endregion
    }
}
