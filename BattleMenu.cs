using System;
using System.IO;
//using Player;
using Enemies;

namespace Dungeon_Redux
{
    public class BattleMenu
    {
        public int Battle(Player p, Enemy e){ //0 alive, 1 dead, 2 enemy died, 3 error
            if(p.health < 1){
                Console.WriteLine("Looks like you died.");
                p.dead = true;
                return 1; 
            }
            if(e.health < 1){
                return 2;
            }
            Console.WriteLine("\n {0} \t HP: {1}", e.name, e.health);
            Console.WriteLine("\n HP: {0} \t MP: {1} \t ST: {2} \t Potions: {3} \t Level: {4}", p.health, p.MP, p.stamina, p.numHealthPotions, p.Lvl);
            Console.WriteLine("1. Attack");
            Console.WriteLine("2. Cast a Spell");
            Console.WriteLine("3. Use Health Potion");
            Console.WriteLine("4. Defend");
            Console.WriteLine("5. Run");
            switch(Int32.Parse(Console.ReadLine())){
                case 1: //attack with weapon
                    int weapon = WeaponSelectMenu(p);
                    e.takeDamage(p.Attack(weapon));
                    //p = e.effect(p);
                    if (e.health > 0)
                    {
                        p.health = p.health - e.Attack();
                    }
                    break;
                case 2: //cast spell
                    int spell = SpellSelectMenu(p);
                    if(spell == -1){ //no spells to cast
                        e.takeDamage(0);
                    }
                    else{
                        e.takeDamage(p.UseSpell(spell));
                    }
                    if(e.getHealth() < 1){
                        break;
                    }
                    p.health = p.health - e.Attack();
                    break;
                case 3: //Heal
                    if(p.numHealthPotions > 0){
                        p.heal();
                    }
                    p.health = p.health - e.Attack();
                    break;
                case 4: //Defend
                    p.health = p.health - Convert.ToInt32(Math.Floor((0.5 * e.Attack())) + (0.33*p.stats["defence"]));
                    break;
                case 5: //Run
                    Console.WriteLine("You look around youu for a way out of this fight");
                    if (p.GetSpeed() > e.speed)
                    {
                        if (p.stamina > 0)
                        {
                            Console.WriteLine("there's an opening and you run for it!");
                            Console.WriteLine("You made it away!");
                            p.stamina--;
                            p.score--;
                            return 2;
                        }
                        else
                        {
                            Console.WriteLine("You're too tired to run");
                        }
                    }
                    else
                    {
                        Console.WriteLine("You try to run but the {0} is too fast for you!", e.name);
                    }
                    p.health = p.health - e.Attack();
                    break;
                default:
                    break; 
            }
            return 0;
        }
        static int WeaponSelectMenu(Player p){
            Console.WriteLine("--------- Choose Your Weapon ---------");
            int index = 1; //what number weapon is it
            for(int i = 0; i < p.WeaponList.Length; i++){
                if(p.WeaponList[i].name != "Empty"){
                    Console.WriteLine("{0}. {1}", index, p.WeaponList[i].name);
                    index++;
                }
            }
            //Console.WriteLine("Out of loop");
            string selStr; 
            //make sure input is a number
            while(true){
                selStr = Console.ReadLine();
                if(String.Compare(selStr, "0") > 0 && String.Compare(selStr, "9") < 0){
                    break;
                }
            }
            int selInt = Convert.ToInt32(selStr);
            Console.WriteLine(selInt);
            if(selInt >= p.WeaponList.Length){
                Console.WriteLine("You reach for an imaginary weapon, get a hold of yourself!");
                selInt = 1;
            }
            return selInt-1;
        }
        static int SpellSelectMenu(Player p){
            int index = 1; //what number spell is it
            Console.WriteLine("--------- Choose Your Spell ---------");
            for(int i = 0; i < p.SpellBook.Length; i++){
                if(p.SpellBook[i].name != ""){
                    Console.WriteLine("{0}. {1} \t {2}", index, p.SpellBook[i].name, p.SpellBook[i].description);
                    index++;
                }
            }
            if(index == 1){
                Console.WriteLine("You reach your hand out and shout gibberish... nothing happened...");
                return -1;
            }
            //Console.WriteLine("Out of loop");
            string selStr = Console.ReadLine();
            int selInt = Convert.ToInt32(selStr);
            if(selInt >= p.SpellBook.Length){
                Console.WriteLine("You reach your hand out and shout gibberish... nothing happened...");
                selInt = 1;
            }
            return selInt-1;
        }
    }
}