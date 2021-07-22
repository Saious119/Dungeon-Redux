using System;
using System.IO;
using Enemies;

namespace Dungeon_Redux
{
    public class EnemyGenerator
    {
        public Enemy Generate(int day, int hour){
             Random random = new Random();
            //var file = Directory.GetFiles("Enemies","*.cs");
            //Console.WriteLine("Enemy File = {0}", file);
            int index = 0;
            if(day > 0 && day < 3){
                if(day == 2 && hour >= 20){
                    Console.WriteLine("Bear time");
                    index = 7;
                }
                else{
                    index = random.Next(1,7);
                }
            }
            else if(day >= 3 && day < 5){
                if(day == 4 && hour >= 20){
                    Console.Clear();
                    Console.WriteLine("*You see that the cave comes to a point where 20 foot steel doors stand in your way to the next area.*");
                    Console.WriteLine("*As you approach the door you hear a deep voice saying 'None shall pass through the gates of Hell without permission!'*");
                    Console.WriteLine("*Huge flames suddenly appear before the door and a giant red man draped in chains and breathing fire appears, wielding a giant hammer!*");
                    index = 12;
                }
                else{
                    index = random.Next(8, 12);
                }
            }
            else if(day >= 5 && day < 7){
                if(day == 6 && hour >= 20){
                    if(random.Next(1,3) == 1){
                        Console.Clear();
                        Console.WriteLine("As you walk deeper into hell you see a 50 ft dog with 3 heads!");
                        Console.WriteLine("He paces back and forth in from of a bridge that leads even deeper into the depths of hell.");
                        Console.WriteLine("Welp, we made it this far, might as well go farther.");
                        index = 17;
                    }
                    else{
                        Console.Clear();
                        Console.WriteLine("As you walk deeper into hell you see a 50 ft dog with 3 heads!");
                        Console.WriteLine("He paces back and forth in front of a bridge that leads even deeper into the depths of hell.");
                        Console.WriteLine("Welp, we made it this far, might as well go farther.");
                        Console.WriteLine("Wait! What's that to the left?");
                        Console.WriteLine("Another bridge! There seems to be some dinosaur, like a Pterodactyl?");
                        Console.WriteLine("You go and approach the Pterodactyl.");
                        index = 18;
                    }
                }
                else{
                    index = random.Next(13, 17);
                }
            }
            else if(day > 6){
                if((day == 7 && hour >= 20) || day > 7){
                    Console.Clear();
                    Console.WriteLine("You see off in the distance a demonic castle.");
                    Console.WriteLine("You run to it bursting through the gran1d doors into the main hall");
                    Console.WriteLine("There on a throne you see a huge dark demon king with a crown");
                    index = 23;
                }
                else{
                    index = random.Next(19, 23);
                }
            }
            switch(index){
                case 1:
                    Boar b = new Boar();
                    b.Create();
                    return b;
                case 2:
                    Wolf w = new Wolf();
                    w.Create();
                    return w;
                case 3:
                    SuspicousRock rock = new SuspicousRock();
                    rock.Create();
                    return rock;
                case 4:
                    Bats bats = new Bats();
                    bats.Create();
                    return bats;
                case 5:
                    Bunny bun = new Bunny();
                    bun.Create();
                    return bun;
                case 6:
                    Snake s = new Snake();
                    s.Create();
                    return s;
                case 7:
                    Bear bear = new Bear();
                    bear.Create();
                    return bear;
                case 8:
                    SuspicousRock rock2 = new SuspicousRock();
                    rock2.Create();
                    return rock2;
                case 9:
                    Goblin g = new Goblin();
                    g.Create();
                    return g;
                case 10:
                    Hobgoblin hg = new Hobgoblin();
                    hg.Create();
                    return hg;
                case 11:
                    SavageBarbarian sb = new SavageBarbarian();
                    sb.Create();
                    return sb;
                case 12:
                    HellsGatekeeper HGK = new HellsGatekeeper();
                    HGK.Create();
                    return HGK;
                case 13: 
                    Demon De = new Demon();
                    De.Create();
                    return De;
                case 14:
                    DemonicBoar DB = new DemonicBoar();
                    DB.Create();
                    return DB;
                case 15:
                    SuspicousRock rock3 = new SuspicousRock();
                    rock3.Create();
                    return rock3;
                case 16:
                    Pheonix p = new Pheonix();
                    p.Create();
                    return p;
                case 17:
                    Cerberus C = new Cerberus();
                    C.Create();
                    return C;
                case 18:
                    Peter peter = new Peter();
                    peter.Create();
                    return peter;
                case 19:
                    DemonGeneral DG = new DemonGeneral();
                    DG.Create();
                    return DG;
                case 20:
                    SavageCaveDweller SCD = new SavageCaveDweller();
                    SCD.Create();
                    return SCD;
                case 21:
                    SuspicousRock rock4 = new SuspicousRock();
                    rock4.Create();
                    return rock4;
                case 22:
                    Dragon dr = new Dragon();
                    dr.Create();
                    return dr;
                case 23:
                    Chad chad = new Chad();
                    chad.Create();
                    return chad;
                default:
                    Console.WriteLine("\nERROR: No enemy found at index {0}", index);
                    Console.WriteLine("You get a Tutorial Bunny for breaking the game");
                    TutorialBunny tbBad = new TutorialBunny();
                    tbBad.Create();
                    return tbBad; 
            }
        }
    }
}