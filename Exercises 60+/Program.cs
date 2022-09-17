cards card = new cards();
card.Createcards();
Deck deck1 = new Deck();
int num = 14;
foreach (cards c in Deck.TheDeck)
{
    if (c.Type == Suits.Hearts)
    {
        Console.WriteLine($"{c.Value} is {num}");
        num--;

    }
}


Random R = new Random();
R.Next(0,53);






enum Rank
{
    Two,
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight,
    Nine,
    Ten,
    Jack,
    Queen,
    King,
    Ace
};
enum Suits
{
    Hearts,
    Diamonds,
    Spades,
    Clubs

}

class cards
{

    public Rank Value { get; set; }
    public Suits Type { get; set; }
    

  
    public cards(Rank value, Suits suit)
    {
        this.Value = value;
        this.Type = suit;


    }
   public cards()
    {
        

    }
    public void Createcards()
    {
        

        foreach (Suits s in Enum.GetValues(typeof(Suits)))
        {

            foreach (Rank r in Enum.GetValues(typeof(Rank)))
            {
                cards newvcard = new cards(r, s);
                
                Deck.TheDeck.Push(newvcard);
            }
            


        }

    }




}
 class Deck : cards
{
    public static  Stack<cards> TheDeck = new Stack<cards>();

    public Deck()
    {
        
    }

    

}