using Cards_And_Methods;

List<Cards> DeckofCards = new List<Cards>();
List<Cards> Player1list = new List<Cards>();
List<Cards> Player2list = new List<Cards>();
Stack<Cards> Player1 = new Stack<Cards>();
Stack<Cards> Player2 = new Stack<Cards>();
Stack<Cards> War_FaceDown_Cards = new Stack<Cards>();
    

MakingDecks.CreateDeck(DeckofCards);
MakingDecks.ShuffleDeck(DeckofCards);
MakingDecks.SplitDeck(DeckofCards, Player1list);
MakingDecks.SecondDeck(DeckofCards,Player1list,Player2list);
Console.WriteLine(DeckofCards.Count);

//foreach (Cards c in DeckofCards)
//{
//    Console.WriteLine(c);
//}
//Console.WriteLine("===================");
//foreach (Cards c in Player1list)
//{
//    Console.WriteLine(c);
//}
//Console.WriteLine("===================");
//foreach (Cards c in Player2list)
//{
//    Console.WriteLine(c);
//}













pushingtostack(Player1list, Player2list, Player1, Player2);

    MainMethod(DeckofCards, Player1list, Player2list, Player1, Player2, War_FaceDown_Cards);    
   



Console.WriteLine();
Console.WriteLine($"Player1 has {Player1list.Count} cards, player2 has {Player2list.Count} cards");





static void MainMethod(List<Cards> DeckofCards,List<Cards> Player1list,List<Cards> Player2list,Stack<Cards> Player1,Stack<Cards> Player2,Stack<Cards> War_FaceDown_Cards)
{
    bool stop = false;
    bool wenttowar = false;
    int turncount = 0;

    int warcount = 0;
    do
    {
        Console.WriteLine("=============== Battle Ground ================");

        turncount++;
        Console.WriteLine($"Start of Turn: {turncount}");
        Cards card1 = Player1.Pop();
        Cards card2 = Player2.Pop();


        Console.WriteLine();
        Console.WriteLine($"Player 1 drew: {card1}");
        Console.WriteLine();
        Console.WriteLine($"Player 2 drew: {card2}");
        Console.WriteLine();
        bool GoToWar = AreCardsTheSame(card1, card2); // Determins if the cards are the same. if they are  it starts the War part of Code. else continues.
        bool WarOver = false;



        if (GoToWar) // if Cards are the Same
        {
            // WarOver Loop Starts
            while (!WarOver) // While the war is not over ** this is here for the chance/case of multiple wars
            {
                if (warcount >= 1) // war count again is for the case of more than 1 war
                {
                    Console.WriteLine("Player1 and Player2 have the same card again! Wow A War on top of an other War!");
                }
                else
                {
                    Console.WriteLine($"Player1 and Player2 have the same card on the table, its time for War! ");
                }
                War(Player1, Player2, War_FaceDown_Cards, Player1list, Player2list, card1, card2); // Goes into The War Function which removes cards ffrom PlayersList and adds cards to middle of table
                card1 = Player1.Pop();
                card2 = Player2.Pop();
                Console.WriteLine($"For the War! Player 1 drew: {card1}");
                Console.WriteLine($"for the War! Player 2 drew: {card2}");
                warcount++; // Adds to the warcount so IF the cards are the same it will know to use a different CW. IE instead of line 70, it will use line 66
                GoToWar = AreCardsTheSame(card1, card2);
                if (!GoToWar) // if The cards are not the same then WarOver = True which gets us out of the go to WarOver  WarLoop
                {
                    WarOver = true;

                }
                // WaroverLoop ends 

            }

            int WontheWar = WhoWon(card1, card2); // this takes the cards from lines 73 and 74 and pushes them into the WhoWon Function

            Console.WriteLine("Soo!");

            Console.WriteLine();
            if (WontheWar < 0)
            {
                int count = 0; // here top show that player 1 did indeed add 6 cards from the pile/middle of the table to his own deck


                foreach (Cards c in War_FaceDown_Cards)
                {
                    count++;
                    Player1list.Add(c);
                    c.ToString(); // to show  which cards exactly are being added

                }
                Console.WriteLine($"Player1 Won the war and added {count} deck");


            }
            else if (WontheWar > 0)
            {
                int count = 0;// here top show that player 2 did indeed add 6 cards from the pile/middle of the table to his own deck


                foreach (Cards c in War_FaceDown_Cards)
                {
                    count++;
                    Player2list.Add(c);
                    c.ToString();// to show  which cards exactly are being added

                }
                Console.WriteLine($"Player2 Won the war and added {count} deck");



            }

            wenttowar = true;
            // break; // figure out how to continue after a war with out ending game
        }
        else
        {
            if (wenttowar == false)
            {

                BattleWinner(card1, card2, Player1list, Player2list);
            }
            else
            {
                Console.WriteLine("Time to start from the top");
            }


        }

        Console.WriteLine();

        Console.WriteLine();
        Console.WriteLine($"End of Turn :{turncount}");

        Console.WriteLine("===============================");

        pushingtostack(Player1list, Player2list, Player1, Player2);
        SeeCardCount(Player1list, Player2list);
        Console.WriteLine();
        wenttowar = false;
        Thread.Sleep(2000);
        Console.Clear();
    } while (turncount < 22); //// <----------- Enter the Turn count you want the game to stop on.
}
static bool SkipTurns()
{
    while (true)
    {
        Console.Write("Would you like to skip (X) amount of turns ahead in the game? Y/N:");
        string respone = Console.ReadLine().ToLower();
        if (respone == "yes" || respone == "y")
        {
            return true;
        }
        else if (respone == "no" || respone == "n")
        {
            return false;
        }
        else
        {
            Console.WriteLine("Please Enter Yes/Y or No/N");
        }
    }
    
}
static int HowManyTurns(string response)
{
    Console.WriteLine("How many turns would you like to skip?");
    
   if(Numbervalidator(response))
    {
        int numberofTurns = int.Parse(response);
        return numberofTurns;
    }
   else return 0;
   

}
static bool Numbervalidator(string userinput)
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
static void BattleWinner(Cards card1,Cards card2,List<Cards>pl1,List<Cards>pl2)
{
    int BattleWinner = WhoWon(card1, card2);
    if (BattleWinner == -1)
    {
        pl1.Remove(card1);
        pl1.Add(card1);
        pl1.Add(card2);
        pl2.Remove(card2);
        Console.WriteLine($"Player 1 won this Battle");

    }
    else if (BattleWinner == 1)
    {
        pl2.Remove(card2);
        pl2.Add(card2);
        pl2.Add(card1);
        pl1.Remove(card1);
        Console.WriteLine($"Player 2 won this Battle");

    }



}
static void pushingtostack(List<Cards> p1l, List<Cards> p2l, Stack<Cards> p1, Stack<Cards> p2)
{

    p1.Clear();

    p2.Clear();
    List<Cards> newpl1 = new List<Cards>(p1l);
    List<Cards> newpl2 = new List<Cards>(p2l);
    newpl1.Reverse();
    newpl2.Reverse();
    foreach (Cards c in newpl1)
    {
        p1.Push(c);
    }
    foreach (Cards c in newpl2)
    {
        p2.Push(c);
    }
 
}
static void addingtostack(List<Cards> p1l, List<Cards> p2l, Stack<Cards> p1, Stack<Cards> p2, int count)
{
    

        p1.Clear();

        p2.Clear();
        foreach (Cards c in p1l)
        {
            p1.Push(c);
        }
        foreach (Cards c in p2l)
        {
            p2.Push(c);
        }
    //for (int i = 1; i <= count; i++)
    //{
        
    //    Console.WriteLine($"*****{p1.Pop()}");
    //    Console.WriteLine($"{p2.Pop()}");
    //}
    
}

static bool AreCardsTheSame(Cards p1, Cards p2)
{
   

    bool draw = false;
    int cardValue1 = FC_to_Num1(p1);
    int cardValue2 = FC_to_Num2(p2);
    if (cardValue1 > cardValue2)
    {

        

        draw = false;

     
    }
    else if (cardValue1 < cardValue2)
    {
      
        draw = false;
     

    }
    else
    {
        //Console.WriteLine($"Player1 and Player2 have the same card on the table, its time for War! ");
        draw = true;
    }
    

    return draw;

}
static int WhoWon(Cards p1,Cards p2)
{
   
    // If Player 1 wins, will return -1, if player 2 wins then returns 1 
    int winner = 0;

    


    int cardValue1 = FC_to_Num1(p1);
    int cardValue2 = FC_to_Num2(p2);
    if (cardValue1 > cardValue2)
    {

       

        winner = -1;

     

    }
    else if (cardValue1 < cardValue2)
    {
      
        winner = 1;
    

    }
    // Might get rid of this code, as might be unnecessary 
    else
    {
        Console.WriteLine($"Player1 and Player2 have the same card on the table, its time for War! ");
        winner = 0;
    }
    // ^^ 
   

    return winner;

}

 static void War(Stack<Cards> p1, Stack<Cards> p2, Stack<Cards> fdc, List<Cards> pl1, List<Cards> pl2,Cards c1, Cards c2)
{
    fdc.Clear();
    fdc.Push(c1);
    fdc.Push(c2);
    pl1.Remove(c1);
    pl2.Remove(c2);
   
    for (int i = 1; i <= 3; i++)
    {
       
        Cards facedown1 = p1.Pop(); // taking the top card from the stack1 player 1 
        Console.WriteLine($"p1s fd card is {facedown1}"); // can get rid of this if we want, just helps visualize what was won for confirmation.

        Cards facedown2 = p2.Pop(); // taking the top card from the stack2 player 2 
        Console.WriteLine($"p2s fd card is {facedown2}");// can get rid of this if we want, just helps visualize what was won for confirmation.


        fdc.Push(facedown1); // adding the top card from stack 1 to the middle of the pile. the stack/list/pile of cards that will be taken by the winner at the end
        fdc.Push(facedown2); // adding the top card from stack 1 to the middle of the pile. the stack/list/pile of cards that will be taken by the winner at the end

        pl1.Remove(facedown1); // removing the card from the main source list for player 1
        pl2.Remove(facedown2); // removing the card from the main source list for player 2

    }


}
static int FC_to_Num1(Cards p1)
{
    Cards _card1 = p1;
    
    int cardValue1 = _card1.Number;
    
   


    if (_card1.FaceCards == "Jack")
    {
        cardValue1 = 11;

    }
    else if (_card1.FaceCards == "Queen")
    {
        cardValue1 = 12;


    }
    else if (_card1.FaceCards == "King")
    {
        cardValue1 = 13;

    }
    else if (_card1.FaceCards == "Ace")
    {
        cardValue1 = 14;
    }
    
    return cardValue1;
}
static int FC_to_Num2(Cards p2)
{
    Cards _card2 = p2;

    int cardValue2 = _card2.Number;




    if (_card2.FaceCards == "Jack")
    {
        cardValue2 = 11;

    }
    else if (_card2.FaceCards == "Queen")
    {
        cardValue2 = 12;


    }
    else if (_card2.FaceCards == "King")
    {
        cardValue2 = 13;

    }
    else if (_card2.FaceCards == "Ace")
    {
        cardValue2 = 14;
    }

    return cardValue2;

    //bool isfaceCard1 = false;
    //bool isfaceCard2 = false;
    //Cards _card1 = p1;
    //Cards _card2 = p2;
    //int cardValue1 = _card1.Number;
    //int cardValue2 = _card2.Number;
    //string cardsuit1 = _card1.Suit;
    //string cardsuit2 = _card2.Suit;

    //if (_card1.FaceCards == "Joker")
    //{
    //    cardValue1 = 11;
    //    isfaceCard1 = true;
    //}
    //else if (_card1.FaceCards == "Queen")
    //{
    //    cardValue1 = 12;
    //    isfaceCard1 = true;

    //}
    //else if (_card1.FaceCards == "King")
    //{
    //    cardValue1 = 13;
    //    isfaceCard1 = true;

    //}
    //else if (_card1.FaceCards == "Ace")
    //{
    //    cardValue1 = 14;
    //    isfaceCard1 = true;

    //}

    //if (_card2.FaceCards == "Joker")
    //{
    //    cardValue2 = 11;
    //    isfaceCard2 = true;
    //}
    //else if (_card2.FaceCards == "Queen")
    //{
    //    cardValue2 = 12;
    //    isfaceCard2 = true;
    //}
    //else if (_card2.FaceCards == "King")
    //{
    //    cardValue2 = 13;
    //    isfaceCard2 = true;

    //}
    //else if (_card2.FaceCards == "Ace")
    //{
    //    cardValue2 = 14;
    //    isfaceCard2 = true;

    //}
    //return cardValue2;
}
static void SeeCardCount(List<Cards> p1, List<Cards>p2)
{
    Console.WriteLine("Do you want to see how many cards both player has in their deck?");
    string useranswer = Console.ReadLine().ToLower();
    if (useranswer == "yes" || useranswer == "y")
    {
        
            Console.WriteLine();
            int cardcount1 = p1.Count;
            Console.WriteLine($"Player 1 has:{cardcount1} cards");
            int cardcount2 = p2.Count;
            Console.WriteLine($"Player 2 has:{cardcount2} cards");
        
    }
    else
    {
        Console.WriteLine("No Worries.");
    }
}
