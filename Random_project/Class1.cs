
namespace Cards_And_Methods
{
  
     class MakingDecks
    {

       

      

        public static Cards RandomCard(List<Cards> deck)
        {
            int randomCard = randomIndex(deck);
            //Console.WriteLine($"{deck[randomCard]}");
            return deck[randomCard];

        }
       public  static int randomIndex(List<Cards> deck)
        {
            Random rand = new Random();
            int indexnum = 1;
            //int cardCount = deck.Count;

            return indexnum = rand.Next(0, deck.Count);
        }
        public static void FindMissingCard(List<Cards> list1,List<Cards>list2)
        {
            foreach(Cards c in list1)
            {
                if (!list2.Contains(c))
                {
                    Console.WriteLine(c);
                    list2.Add(c);
                }
            }
            
        }
       public static void ShuffleDeck(List<Cards> MainDeck)
        {
            int count = 0;
            List<Cards> shuffle = new List<Cards>();
            do
            {
                



                int random = randomIndex(MainDeck);
                //deck.Add(player[random]);
                if (!shuffle.Contains(MainDeck[random]))
                {

                    //Console.WriteLine(player[random]);
                    shuffle.Add(MainDeck[random]);
                    count++;

                }

            }while (count < MainDeck.Count);

            MainDeck.Clear();
            MainDeck.AddRange(shuffle);
            //return deck;
        }
        public  static void CreateDeck(List<Cards> _deckofcards)
        {
              
         string[] face_card = { "Jack", "Queen", "King", "Ace" };
            for (int i = 2; i <= 10; i++)
            {
                _deckofcards.Add(new Hearts(i));
                _deckofcards.Add(new Diamonds(i));
                _deckofcards.Add(new Spades(i));
                _deckofcards.Add(new Clubs(i));

            }
            foreach (string cardtype in face_card)
            {
                _deckofcards.Add(new Hearts(cardtype));
                _deckofcards.Add(new Diamonds(cardtype));
                _deckofcards.Add(new Spades(cardtype));
                _deckofcards.Add(new Clubs(cardtype));
            }
        }

       public static void SplitDeck(List<Cards> _deckofcards, List<Cards> player)
        {
            
                bool equaldivide = false;
               
                for (int i = _deckofcards.Count; i > 0; i--)
                {
                    while (!equaldivide)
                    {
                        if (player.Count < 26)
                        {
                            int Indexnum = randomIndex(_deckofcards);
                            if (_deckofcards.Contains(_deckofcards[Indexnum]))
                            {
                                //DeckofCards.RemoveAt(Indexnum);

                                if (!player.Contains(_deckofcards[Indexnum]))
                                {
                                    player.Add(_deckofcards[Indexnum]);

                                };
                            };
                        }
                        else
                        {
                            equaldivide = true;
                        }
                    }
                }



        }

        public static void SecondDeck(List<Cards> deckofcards, List<Cards> p1, List<Cards> p2)
        {
            foreach (Cards Card in deckofcards)
            {

                if (!p1.Contains(Card))
                {
                    p2.Add(Card);

                }
            }
        }

    }


    class Cards
        {
            public int Number;
            public string Suit;
            public string Color;
            public string FaceCards;
            public string Joker;


            public override string ToString()
            {
                return "Oooppps";
            }


        }
        class Hearts : Cards
        {


         
            public Hearts(int num)
            {
                Number = num;
                Suit = "Hearts";
                Color = "Red";

            }
            public Hearts(string facecard)
            {
                FaceCards = facecard;
                Suit = "Hearts";
                Color = "Red";
            }

            public override string ToString()
            {
                if (Number > 0)// can put null here work on this. put note here for memory help :) 
                {
                    return $"{Number} of {Suit}";
                }
                else
                {
                    return $"{FaceCards} of {Suit}";
                }
            }

        }
        class Diamonds : Cards
        {


      
            public Diamonds(int num)
            {
                Number = num;
                Suit = "Diamonds";
                Color = "Red";
            }
            public Diamonds(string facecard)
            {
                FaceCards = facecard;
                Suit = "Diamonds";
                Color = "Red";
            }
            public override string ToString()
            {
                if (Number > 0)
                {
                    return $"{Number} of {Suit}";
                }
                else
                {
                    return $"{FaceCards} of {Suit}";
                }
            }

        }
        class Spades : Cards
        {


            public Spades(int num)
            {
                Number = num;
                Suit = "Spades";
                Color = "Black";
            }
            public Spades(string facecard)
            {
                FaceCards = facecard;
                Suit = "Spades";
                Color = "Black";
            }

            public override string ToString()
            {
                if (Number > 0)
                {
                    return $"{Number} of {Suit}";
                }
                else
                {
                    return $"{FaceCards} of {Suit}";
                }
            }

        }
        class Clubs : Cards
        {


            public Clubs(int num)
            {
                Number = num;
                Suit = "Clubs";
                Color = "Black";
            }
            public Clubs(string facecard)
            {
                FaceCards = facecard;
                Suit = "Clubs";
                Color = "Black";
            }

            public override string ToString()
            {
                if (Number > 0)
                {
                    return $"{Number} of {Suit}";
                }
                else
                {
                    return $"{FaceCards} of {Suit}";
                }
            }

        }
}
