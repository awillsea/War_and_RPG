using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public  class Methods
    {
        public static void MainMenu()
        {
            Console.WriteLine("Welcome to \"Title in Progress\" ");
            Console.WriteLine("Main Menu");
            Console.WriteLine("(1) Basics");
            Console.WriteLine("(2) Select Character Type.");
            string response = Console.ReadLine();
            int userSelection = 0;
            while (Numbervalidator(response))
            {
                userSelection = int.Parse(response);
                if(userSelection == 1)
                {
                    BasicsMenuOption();
                }
                else
                {
                   

                }

            }
        }
        public static void BasicsMenuOption()
        {
            Console.WriteLine("Welcome to Basics!"); 
            Console.WriteLine();// insert basic outline for game
            Console.WriteLine("Which Character Type Would you like to learn more about?");
            Console.WriteLine("(1) Warrior: ");
            Console.WriteLine("(2) Mage: ");
            Console.WriteLine("(3) Rouge: ");
            string userchoice = Console.ReadLine();
            int choice = 0;
            while (Numbervalidator(userchoice))
            {
                choice = int.Parse(userchoice);
                if(choice == 1)
                {
                    Warrior.Warriorinfo();
                    break;
                }
                else if(choice == 2)
                {
                    Mage.MageInfo();
                    break;
                }
                else
                {
                    Rouge.RougeInfo();
                    break;
                }
            }
            

        }
        public static CharacterType CharacterSelectionMenu()
        {
            Console.WriteLine("Please Select the Character type you wish to play as:");
            Console.WriteLine("(1) Warrior: ");
            Console.WriteLine("(2) Mage: ");
            Console.WriteLine("(3) Rouge: ");
            string characterchoice = Console.ReadLine();
            int character = 0;
            Warrior warrior = null;
            Mage mage = null;
            Rouge rouge = null;
            while (Numbervalidator(characterchoice))
            {
                character = int.Parse(characterchoice);
                if(character == 1)
                {
                    Console.Write("Please enter the name you wish to give your Warrior: ");
                    string WarriorName = Console.ReadLine();
                    Warrior PlayersCharacter = new Warrior(WarriorName, 0, 0, 20, 5, 15);
                    warrior =  PlayersCharacter;

                }
                else if (character == 2)
                {
                    Console.Write("Please enter the name you wish to give your Mage: ");
                    string MageName = Console.ReadLine();
                    Mage PlayerCharacter = new Mage(MageName);
                    mage =  PlayerCharacter;
                }
                else
                {
                    Console.Write("Please enter the name you wish to give your Rouge: ");
                    string RougeName = Console.ReadLine();
                    Rouge PlayerCharacter = new Rouge(RougeName);
                    rouge = PlayerCharacter;

                }

            }
        }
        public static bool Numbervalidator(string userinput)
        {
            int userNum = 0;
            bool validNum = false;
            bool valid = int.TryParse(userinput, out userNum);
            if (valid)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static double RollBonus(double die, double dmg)
        {
            if (die <= 2)
            {
                return dmg;
            }
            else if (die <= 4)
            {
                return Math.Round(dmg * 1.1);
            }
            else if (die <= 5)
            {
                return Math.Round(dmg * 1.25);
            }
            else
            {
                return Math.Round(dmg * 1.55);
            }
        }
        public static double DeterminBaseDamage(double p1Atk, double p2Def)
        {
            return p1Atk * 100 / (100 + p2Def);

        }
        public static double WarriorRange_Influence(double attack, double defense, double range)
        {
            if (range == 2)
            {
                return Math.Round(DeterminBaseDamage(attack, defense) * 1.5);

            }
            else if (range >= 3)
            {
                return Math.Round(DeterminBaseDamage(attack, defense) * .8);
            }
            else
            {
                return Math.Round(DeterminBaseDamage(attack, defense));
            }

        }
        public static double MageRange_Influence(double attack, double defense, double range)
        {
            if (range <= 2)
            {
                return Math.Round(DeterminBaseDamage(attack, defense) * .5);
            }
            else if (range == 3)
            {
                return Math.Round(DeterminBaseDamage(attack, defense));
            }
            else
            {
                return Math.Round(DeterminBaseDamage(attack, defense) * 1.8);
            }
        }
        public static double RougeRange_Influence(double attack, double defense, double range)
        {
            if (range == 1)
            {
                return Math.Round(DeterminBaseDamage(attack, defense) * 1.8);
            }
            else if (range == 2)
            {
                return Math.Round(DeterminBaseDamage(attack, defense));
            }
            else
            {
                return Math.Round(DeterminBaseDamage(attack, defense) * .5);
            }
        }
        public static double DiceRoll()
        {
            Random R = new Random();
            double die = R.Next(1, 7);
            return die;
        }
    }
}
