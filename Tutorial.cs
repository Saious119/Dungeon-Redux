using System;
using System.IO;
using Player;
using Enemies;

namespace Dungeon_Redux
{
    class Tutorial
    {
        static void run(Player p){
            Console.WriteLine("\nIn this game you'll find yourself fighting enemies at random times");
            Console.WriteLine("you must manage your stamina and health well if you expect to last all 7 days");
            Console.WriteLine("Oh Look! An enemy ... er something");
            TutorialBunny tb = new TutorialBunny();
            tb.Create();
            while(p.health > 0 || e.health > 0){
                Battle(p, tb);
            }
        }
    }
}