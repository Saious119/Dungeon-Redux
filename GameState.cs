using System;
using System.IO;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Dungeon_Redux
{
    public class GameState
    {
        public Player Player = new Player();
        public Time time = new Time();
        public DateTime timestamp = DateTime.Now;

        public GameState init(){
            Player.NewPlayer();
            Player.APPointPlacement();
            time.initTime();
            return this;
        }
        public GameState LoadGame(){
            //read from JSON and return it
            Console.WriteLine("Looking for save file");
            if (File.Exists("save.json"))
            {
                Console.WriteLine("Loading Save File");
                try
                {
                    var jsonInfo = File.ReadAllText(@"save.json");
                    dynamic loadedSave = JsonConvert.DeserializeObject<GameState>(jsonInfo);
                    Console.WriteLine("Loaded save data");
                    return loadedSave;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: {0}", e);
                }
            }
            else
            {
                Console.WriteLine("No save file found...\nCreating new save file");
                init();
                SaveGame();
            }
            return this;
        }
        public int SaveGame(){
            //write to JSON
            Console.WriteLine("Writting Save File... Do Not Close Game");
            try
            {
                var saveFile = Newtonsoft.Json.JsonConvert.SerializeObject(this);
                File.WriteAllText(@"save.json", saveFile);
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception: {0}", e);
                return -1;
            }
            Console.WriteLine("File saved!");
            return 0;
        }
    }
}