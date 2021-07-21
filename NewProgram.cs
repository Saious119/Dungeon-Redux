using System;
using System.IO;
using System.Threading;
using System.Collections.Generic;
using Enemies;
using Weapons;
using Spells;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Reflection;

namespace Dungeon_Redux
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random;
            GameState GameState = new GameState();
            TitleScreen TS = new TitleScreen();
            switch(TitleScreen.Display()){
                case 1:
                    //start a new game
                    GameState = GameState.init();
                    break;
                case 2:
                    //load a game
                    GameState = GameState.LoadGame();
                    break;
                case 4:
                    //check for updates
                    Update update = new Update();
                    update.StartUpdate();
                    //var updateProcess = System.Diagnostics.Process.Start(@"..\win10-x64-Update\Update.exe");
                    //updateProcess.WaitForExit();
                    break;
            }
            /*
            struct HighScore{
                int highScore = 0;
                String highScoreName = "None";
            }
            */
            Time time = new Time();
            time.initTime();
            Thread timeThread = new Thread(new ThreadStart(time.runTime));
            timeThread.IsBackground = true;
            timeThread.Start();
            Player p1 = GameState.Player;
            Console.WriteLine("\nWelcome to the Dungeon \n Survive all 7 days to win!");
            Console.WriteLine("\nWould you like the Tutorial? y/n");
            if(Console.ReadLine() == "y"){
                Tutorial Tutorial = new Tutorial();
                Tutorial.run(p1);
            }
            //TODO: Make overworld Menu class and loop
            //TODO: Make enemy generator, and make it better
            Console.Clear();
            Console.WriteLine("Chad falls to the floor, having used all of his energy he turns to chrimson dust and blows away");
            Console.WriteLine("Congrats, you are now the king of Hell.");
            Console.WriteLine("#############################################");
            Console.WriteLine("#             Thanks For Playing            #");
            Console.WriteLine("#        Find this project on GitHub        #");
            Console.WriteLine("# https://github.com/BoneKing/Dungeon-Redux #");
            Console.WriteLine("#     This game was made by Andy Mahoney    #");
            Console.WriteLine("#            Last Updated 10/20/2020        #");
            Console.WriteLine("#############################################");
        }
    }
}