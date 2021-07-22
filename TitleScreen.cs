using System;
using System.IO;
using System.Threading;

namespace Dungeon_Redux
{
    public class TitleScreen 
    {
        public static int Display(){
            Console.WriteLine("WELCOME TO DUNGEON REDUX\n\n\n\n\n");
            Console.WriteLine("1. New Game");
            Console.WriteLine("2. Continue Game");
            Console.WriteLine("3. Quit");
            Console.WriteLine("4. Check for Updates");
            switch(Console.ReadLine()){
                case "1":
                    return 1;
                case "2":
                    return 2;
                case "3":
                    Environment.Exit(0);
                    return -1;
                case "4":
                    return 4;
                default:
                    Display();
                    break;
            }
            return 0;
        }
    }
}