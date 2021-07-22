using System;
using System.IO;
using Enemies;

namespace Dungeon_Redux
{
    public class Tutorial
    {
        public static void run(Player p){
            Console.WriteLine("\nIn this game you'll find yourself fighting enemies at random times");
            Console.WriteLine("you must manage your stamina and health well if you expect to last all 7 days");
            Console.WriteLine("Oh Look! An enemy ... er something");
            TutorialBunny tb = new TutorialBunny();
            tb.Create();
            BattleMenu BattleMenu = new BattleMenu();
            int battleStatus = 0;
            while(battleStatus == 0){
                battleStatus = BattleMenu.Battle(p, tb);
            }
            if(battleStatus == 3){
                Console.WriteLine("ERROR: BattleMenu Ran into an error");
            }
        }
    }
}