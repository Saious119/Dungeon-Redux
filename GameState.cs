using System;
using System.IO;
using System.Globalization;

namespace Dungeon_Redux
{
    public class GameState
    {
        public Player Player = new Player();
        DateTime timestamp = DateTime.Now;

        public GameState init(){
            Player.NewPlayer();
            Player.APPointPlacement();
            Time time = new Time();
            time.initTime();
            return this;
        }
        public GameState LoadGame(){
            //read from JSON and return it
            return this;
        }
        public int SaveGame(GameState gamestate){
            //write to JSON
            return 1;
        }
    }
}