using System;
using System.IO;
using Enemies;
using Weapons;

namespace Dungeon_Redux
{
    public class OverWorldMenu
    {
        public void Menu(Player p1, Time time, GameState GS){
            GameState GState = GS;
            while (!p1.getdead() || !time.endTime())
            {
                p1.CalculateHungry(time.day, time.hour);
                if(p1.dead == true){
                    break;
                }
                Console.WriteLine("\n1. Walk deeper into the cave.");
                Console.WriteLine("2. Eat some food.");
                Console.WriteLine("3. Rest.");
                Console.WriteLine("4. Save.");
                Console.WriteLine("5. Quit.");
                switch(Console.ReadLine()){
                    case "1":
                        Random random = new Random();
                        EnemyGenerator EGen = new EnemyGenerator();
                        Enemy e = EGen.Generate(time.day, time.hour);
                        if(e.name.Contains("Chad")){
                            FinalBoss(p1, e);
                            p1.score+=2;
                            Console.WriteLine("Score = {0}", p1.score);
                            return;
                        }
                        Console.WriteLine("You decide to keep walking further into the depths.");
                        Console.WriteLine("All of the sudden you get ambushed by a {0}", e.name);
                        BattleMenu BattleMenu = new BattleMenu();
                        int battleStatus = 0;
                        while(battleStatus == 0){
                            battleStatus = BattleMenu.Battle(p1, e);
                        }
                        if(e.name.Contains("Boss")){
                            time.day++;
                            time.hour = 0;
                        }
                        if(p1.dead == true){
                            break;
                        }
                        p1.score++;
                        p1.Exp(1*e.area);
                        Console.WriteLine("Score = {0}", p1.score);
                        int whatToDrop = random.Next(1,3);
                        if(whatToDrop == 1){
                            int item = e.DropItem();
                            if(item == 0){ //no item dropped
                                Console.WriteLine("Nothin useful was found");
                                break; 
                            }
                            else if(item == 1) { //food dropped
                                Console.WriteLine("{0} dropped some food!", e.name);
                                p1.numFood++;
                            }
                            else if(item == 2) { //health potion Dropped
                                Console.WriteLine("{0} dropped a health potion!", e.name);
                                p1.numHealthPotions++;
                            }
                            else {
                                Console.WriteLine("ERROR: invalid item dropped, item num = {0}", whatToDrop);
                            }
                        }
                        else if(whatToDrop == 2){
                            Weapon NewWeapon = e.DropWeapon();
                            if(NewWeapon.name != "Empty"){
                                Console.WriteLine("{0} dropped a {1}", e.name, NewWeapon.name);
                                p1.getWeapon(NewWeapon);
                            }
                            else if(NewWeapon.name == "Empty"){
                                Console.WriteLine("Nothin useful was found");
                            }
                        }
                        else{
                            Console.WriteLine("ERROR: No Drop Option with number {0}", whatToDrop);
                        }
                        time.hour++;
                        Console.WriteLine("day {0} at hour {1}", time.day, time.hour);
                        break;
                    case "2":
                        if(p1.numFood > 0){
                            Console.WriteLine("You ate some food, it helps keep away the hunger");
                            p1.eat(time.day, time.hour);
                        }
                        else{
                            Console.WriteLine("You have no food to eat");
                        }
                        break;
                    case "3":
                        Console.WriteLine("You decide to take a break for a bit");
                        random = new Random();
                        int sleepAttack = random.Next(0,10);
                        if(sleepAttack < 8){
                            p1.HealFist();
                            if(time.hour+4 > 23){
                                time.hour = 23;
                            }
                            else{
                                time.hour+=4;
                            }
                            p1.stamina+=2;
                            p1.health+=15;
                        }
                        else{
                            time.hour+=2;
                            Console.WriteLine("You hear something in your sleep. You awaken to find you are surrounded by shadowy figures!");
                            Console.WriteLine("You're able to fend them off but you did take some damage");
                            p1.health = Convert.ToInt32(Math.Floor(p1.health*.75));
                        }
                        break;
                    case "4":
                        GState.SaveGame();
                        break;
                    case "5":
                        Console.WriteLine("Are you sure you want to quit? y/n");
                        if(Console.ReadLine() == "y"){
                            return;
                        }
                        else{
                            break;
                        }
                    default:
                        Console.WriteLine("Invalid option, try something else.");
                        break;

                }
            }
            Console.WriteLine("Score: {0}", p1.score);
        }
        static public void FinalBoss(Player p1, Enemy e){
            BattleMenu BattleMenu = new BattleMenu();
            BattleMenu.Battle(p1, e);
            if(p1.health < 1){
                return;
            }
            TutorialBunny2 tb2 = new TutorialBunny2();
            tb2.Create();
            BattleMenu.Battle(p1, tb2);
            if(p1.health < 1){
                return;
            }
        }
    }
}