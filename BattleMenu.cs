using System;
using System.IO;
using Player;
using Enemy;

namespace Dungeon_Redux
{
    class BattleMenu
    {
        public int Battle(Player p, Enemy e){ //0 alive, 1 dead, 2 error
            if(p.health < 1){
                Console.WriteLine("Looks like you died.");
                p1.dead = true;
                return 1; 
            }
            Console.WriteLine("\n {0} \t HP: {1}", e.name, e.health);
            Console.WriteLine("\n HP: {0} \t MP: {1} \t ST: {2} \t Potions: {3} \t Level: {4}", p1.health, p1.MP, p1.stamina, p1.numHealthPotions, p1.Lvl);
            Console.WriteLine("1. Attack");
            Console.WriteLine("2. Cast a Spell");
            Console.WriteLine("3. Use Health Potion");
            Console.WriteLine("4. Defend");
            Console.WriteLine("5. Run");
            switch(parseInt(Console.ReadLine())){
                case 1: //attack with weapon
                    int weapon = WeaponSelectMenu(p);
                    e.takeDamage(p.Attack(weapon));
                    p = e.effect(p);
                    p.health = p.health - e.Attack();
                    break;
                case 2: //cast spell
                    int spell = SpellSelectMenu(p1);
                    if(spell == -1){ //no spells to cast
                        e.takeDamage(0);
                    }
                    else{
                        e.takeDamage(p1.UseSpell(spell));
                    }
                    if(e.getHealth() < 1){
                        break;
                    }
                    p1.health = p1.health - e.Attack();
                    break;
                case 3: //Heal
                    if(p1.numHealthPotions > 0){
                        p1.heal();
                    }
                    p1.health = p1.health - e.Attack();
                    break;
                case 4: //Defend
                    p1.health = p1.health - Convert.ToInt32(Math.Floor((0.5 * e.Attack())) + (0.33*p1.stats["defence"]));
                    break;
                case 5: //Run
                    break;
                default:
                    break; 
            }
        }
        static int WeaponSelectMenu(Player p1){
            Console.WriteLine("--------- Choose Your Weapon ---------");
            int index = 1; //what number weapon is it
            for(int i = 0; i < p1.WeaponList.Length; i++){
                if(p1.WeaponList[i].name != "Empty"){
                    Console.WriteLine("{0}. {1}", index, p1.WeaponList[i].name);
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
            if(selInt >= p1.WeaponList.Length){
                Console.WriteLine("You reach for an imaginary weapon, get a hold of yourself!");
                selInt = 1;
            }
            return selInt-1;
        }
        static int SpellSelectMenu(Player p1){
            int index = 1; //what number spell is it
            Console.WriteLine("--------- Choose Your Spell ---------");
            for(int i = 0; i < p1.SpellBook.Length; i++){
                if(p1.SpellBook[i].name != ""){
                    Console.WriteLine("{0}. {1} \t {2}", index, p1.SpellBook[i].name, p1.SpellBook[i].description);
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
            if(selInt >= p1.SpellBook.Length){
                Console.WriteLine("You reach your hand out and shout gibberish... nothing happened...");
                selInt = 1;
            }
            return selInt-1;
        }
    }
}