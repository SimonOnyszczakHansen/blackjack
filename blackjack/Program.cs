namespace blackjack
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Tryk 'T' for at fortsætte");
            char userInterface = char.Parse(Console.ReadLine().ToLower());
            if (userInterface == 't')
            {
                
            }
        }
        
        public class Deck
        {
            private int playerPoints = 0;
            private int computerPoints = 0;
            private string cardType = "";
            private int cardValue = 0;
            Random rnd = new Random();

            public List<Cards> playerCards = new List<Cards>();
            public List<Cards> computerCards = new List<Cards>();

            public int PlayerPoints 
            { 
                get { return playerPoints; } 
            }
            public int ComputerPoints
            {
                get { return playerPoints; }
            }

            int[,] cards = new int[,] 
            { 
                { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 }, 
                { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 },
                { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 },
                { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 },
            };
            public void DrawCard(bool turn)
            {
                bool player = turn;
                if (player == true)
                {
                    int symbol = rnd.Next(0, cards.GetLength(0));
                    int number = rnd.Next(0, cards.GetLength(1));
                    int cardnumber = cards[symbol, number];
                    if (cardnumber > 10)
                    {
                        cardValue = 10;
                    }
                    else
                    {
                        cardValue = cardnumber;
                    }
                    
                    switch(symbol)
                    {
                        case 0:
                            cardType = "Hearts";
                            break;
                        case 1:
                            cardType = "Spades";
                            break;
                        case 2:
                            cardType = "Diamonds";
                            break;
                        case 3:
                            cardType = "Clubs";
                            break;
                    }
                    Cards card = new Cards(cardType, cardValue, cardnumber);
                    playerCards.Add(card);
                    playerPoints += cardValue;
                }
                else
                {
                    int symbol = rnd.Next(0, cards.GetLength(0));
                    int number = rnd.Next(0, cards.GetLength(1));
                    int cardnumber = cards[symbol, number];
                    if (cardnumber > 10)
                    {
                        cardValue = 10;
                    }
                    else
                    {
                        cardValue = cardnumber;
                    }

                    switch (symbol)
                    {
                        case 0:
                            cardType = "Hearts";
                            break;
                        case 1:
                            cardType = "Spades";
                            break;
                        case 2:
                            cardType = "Diamonds";
                            break;
                        case 3:
                            cardType = "Clubs";
                            break;
                    }
                    Cards card = new Cards(cardType, cardValue, cardnumber);
                    computerCards.Add(card);
                    computerPoints += cardValue;
                }





            }
            public struct Cards
            {
                public string CardSymbol 
                {
                    get;
                }
                public int CardRank 
                {
                    get;
                }
                public int CardNumber 
                {
                    get;
                }

                public Cards(string cardSymbol, int cardRank, int cardNumber)
                {
                    this.CardSymbol = cardSymbol;
                    this.CardRank = cardRank;
                    this.CardNumber = cardNumber;
                }

                public override string ToString()
                {
                    if (CardNumber > 10)
                    {
                        string cardWithPicture = "";
                        switch (CardNumber)
                        {
                            case 11:
                                cardWithPicture = "Knight";
                                break;
                            case 12:
                                cardWithPicture = "Queen";
                                break;
                            case 13:
                                cardWithPicture = "King";
                                break;
                            default:
                                break;
                        }
                        return CardSymbol + ":" + cardWithPicture;
                    }
                    else
                    {
                        return CardSymbol + ":" + CardNumber;
                    }
                    return base.ToString();
                }
            }
        }
    }
}