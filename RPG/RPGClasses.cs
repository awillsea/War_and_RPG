using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public class CharacterType
    {
        public string Name { get; set; }
        public double Level { get; set; }

        public double XP { get; set; }


        public double Health { get; set; }
        public double Attack { get; set; }

        public double Defense { get; set; }

        public CharacterType()
        {

        }
        public CharacterType(string name, double level, double xp, double health, double attack, double defense)
        {
            Name = name;
            Level = level;
            XP = xp;
            Health = health;
            Attack = attack;
            Defense = defense;
            
        }
    }
    class Warrior : CharacterType
    {

        public Warrior(string name,double level, double xp, double health, double attack, double defense): base(name, level, xp, health, attack,defense)
        {
            this.Name = name;
            this.Level = level;
            this.XP = xp;
            this.Health = health;
            this.Attack = attack;
            this.Defense = defense;
        }
        public Warrior()
        {

        }
        public static void Warriorinfo()
        {
            Console.WriteLine("(Superior Health, Weak Attack, High Defense.");
            Console.WriteLine("Which equates to these starting stats: 20 Health, 5 Attack, 15 Defense");
            Console.WriteLine("Distance: 1 is no change to DMG, 2 is bonus to DMG, 3-4 Reduction in DMG");
            Console.WriteLine("The Bonus is 1.5 and the reduction is .8");

        }
    }
    class Mage : CharacterType
    {
        public double Level = 1;
        public double xp = 0;
        public double health = 10;
        public double attack = 15;
        public double defense = 10;
        public Mage(string name, double level, double xp, double health, double attack, double defense) : base(name, level, xp, health, attack, defense)
        {   
            this.Name = name;
            this.Level = level;
            this.XP = xp;
            this.Health = health;
            this.Attack = attack;
            this.Defense = defense;
        }
        public  Mage(string name)
        {
            this.Name = name;

       }
        public Mage()
        {

        }

         public static void MageInfo()
        {
            Console.WriteLine("Low Health, High Attack, Weak Defense");
            Console.WriteLine("Which equates to the following starting stats: 10 Health, 15 Attack, 5 Defense");
            Console.WriteLine("Distance: 1-2 is a reduction in DMG, 3 is no change to DMG, 4 is a Bonus to DMG");
            Console.WriteLine("The Bonus is 1.8, and the reduction is .5");

        }
    }
    class Rouge : CharacterType
    {
        public double Level = 1;
        public double xp = 0;
        public double health = 10;
        public double attack = 15;
        public double defense = 10;
        public Rouge(string name, double level, double xp, double health, double attack, double defense) : base(name, level, xp, health, attack, defense)
        {
            this.Name = name;
            this.Level = level;
            this.XP = xp;
            this.Health = health;
            this.Attack = attack;
            this.Defense = defense;
        }
        public Rouge(string name)
        {
            this.Name = name;

        }
        public Rouge()
        {

        }
        public static void RougeInfo()
        {
            Console.WriteLine("Low Health, High Attack, Weak Defense");
            Console.WriteLine("Which equates to the following starting stats: 10 Health, 15 Attack, 5 Defense");
            Console.WriteLine("Distance: 1 is a Bonus to DMG, 2 is no change to DMG, 2-4 is a reduction in DMG");


        }
    }

 

    class Hunter : CharacterType
    {
        public Hunter(string name, double level, double xp, double health, double attack, double defense) : base(name, level, xp, health, attack, defense)
        {
            this.Name = name;
            this.Level = level;
            this.XP = xp;
            this.Health = health;
            this.Attack = attack;
            this.Defense = defense;
        }
    }

}
