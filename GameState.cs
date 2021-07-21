using System;
using System.IO;
using Player;
using System.Globalization;

namespace Dungeon_Redux
{
    class GameState
    {
        Player player = new Player();
        DateTime timestamp = DateTime.Now();

        GameState init(){
            player.NewPlayer();
            player.APPointPlacement();
            Time time = new Time();
            time.init();
        }
        GameState LoadGame(){
            //read from JSON and return it
            return this;
        }
        int SaveGame(GameState gamestate){
            //write to JSON
            return 1;
        }
    }
}