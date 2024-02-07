namespace Card // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CardColor[] colors = new CardColor[] { CardColor.Red, CardColor.Green, CardColor.Blue, CardColor.Yellow };
            CardRank[] cardRanks= new CardRank[] { CardRank.One, CardRank.Two, CardRank.Three, CardRank.Four, CardRank.Five, CardRank.Six, CardRank.Seven, CardRank.Eight, CardRank.Nine, CardRank.Ten, CardRank.DollarSign, CardRank.Percent, CardRank.Caret, CardRank.Ampersand };

            foreach (CardColor color in colors)
            {
                foreach (CardRank cardRank in cardRanks)
                {
                    Card card = new Card(color, cardRank);
                    Console.WriteLine($"The {card.CardColor} {card.CardRank}");
                }
            }
            
            
            
            
        }
    }



    
    public class Card
    {
        
        public CardColor CardColor { get;}
        public CardRank CardRank { get; }


        public Card(CardColor color, CardRank rank)
        {
            CardColor = color;
            CardRank = rank;
        }


        public bool isNumber()
        {
            return !isFace();
        }

        public bool isFace()
        {
            return (CardRank == CardRank.Ampersand || CardRank == CardRank.Caret || CardRank == CardRank.Percent || CardRank == CardRank.DollarSign);
        }
        
        
        
        
    }



    public enum CardColor
    {
        Red,
        Green,
        Blue,
        Yellow
    }

    public enum CardRank
    {
        One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, DollarSign, Percent, Caret, Ampersand
    }
    
    
    
    
    
    
    
    
}