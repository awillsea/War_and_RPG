using RPG;
//Warriors high health,weak attack, high defense
//Mages low health high attack, weak defense
//Rouges low health, high attack, weak defense
//Hunters medium health, medium attack, medium defense
Warrior Alexander_The_Great = new Warrior("Alexander_The_Great", 0, 0, 20, 5, 15);
Mage Merlin = new Mage("Merlin", 0, 0, 10, 15, 5);
Rouge Bond = new Rouge("007", 0, 0, 10, 15, 5);
//Rules for attacks
// ++ = * .3? +++ = .5? -- = /.3? --- = /.5
// if warrior is 1 attack is base/ if 2 spaces attack is ++ / if over attack is --
// if mage is with in 2 spaces attack is ---/ if 3 attack is base /if over attack is +++
// if rouge is within 1 space attack is +++/ if 2 attack is base  /if over attack is ---

//attacking formula
// roll dice 1&2 = low,3&4 = med, 5&6 = high
//low is base
//med is 1.1
//high is 1.25
//crit is  1.55



// ex: p1 = D:100 A: 50 vs p2 = D:50 A:100
// p1.A*100/(100+D)



Console.WriteLine("Welcome to \"Title in Progress\" ");
Console.WriteLine("Main Menu");
Console.WriteLine("(1) Basics");
Console.WriteLine("(2) Select Character Type.");
Console.WriteLine("Please Select the Character Type you wish to be: ");

