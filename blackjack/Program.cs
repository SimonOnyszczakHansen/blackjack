using System.Security.Cryptography.X509Certificates;

namespace blackjack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Our object
            Deck deck = new Deck();

            //to check if its the players turn
            bool playersTurn = true;

            //User interface
            Console.WriteLine("Tryk 'T' for at fortsætte");
            char userInterface = char.Parse(Console.ReadLine().ToLower());
            if (userInterface == 't')
            {

                Console.Clear();//Cleears console
                for (int i = 0; i < 2; i++)//For loop to pick up 2 cards 
                {
                    deck.DrawCard(playersTurn);
                }
                playersTurn = false;//Sets the variable to false 
                for (int i = 0; i < 2; i++)//For loop to pick up 2 cards
                {
                    deck.DrawCard(playersTurn);
                }
                deck.ShowPlayersCards();//shows the cards
                do//It does this if the user dont press "n"
                {
                    Console.WriteLine("Hit (y/n)");//Asks the user if he wants to hit
                    userInterface = char.Parse(Console.ReadLine().ToLower());//Reads what the user said
                    if (userInterface == 'y')//Checks if the user said yes
                    {
                        playersTurn = true;//Indicats that it is the players turn
                        deck.DrawCard(playersTurn);//Draws a card
                    }
                    deck.ShowPlayersCards();//Shows the cards
                } while (userInterface != 'n');
                do
                {
                    if (deck.DealerPoints > 15)//If dealer has over 15
                    {
                        userInterface = 'y';
                        playersTurn = false;//Indicates that it is the dealers turn
                        deck.DrawCard(playersTurn);//Draws a card
                    }
                    else
                    {
                        userInterface = 'n';
                    }
                    deck.ShowTable();//Shows everyones cards
                } while (userInterface != 'n');
                
                if (21 - deck.PlayerPoints < 21 - deck.DealerPoints)//checks if user is closer to 21
                {
                    Console.Clear();//Clears console
                    Console.WriteLine("You win!");//User victory message
                }
                else if (deck.PlayerPoints == deck.DealerPoints)//Checks if it is a draw
                {
                    Console.Clear();//Clears console
                    Console.WriteLine("Both Win");//Draw message
                }
                else
                {
                    Console.Clear();//Clears console
                    Console.WriteLine("Dealer win");//Dealer victory message
                }
            }
        }

        public class Deck
        {
            private int playerPoints = 0;//Creates variable for players ponts
            private int dealerPoints = 0;//Creates variable for dealers points
            private string cardType = "";//Creates variable for card type
            private int cardValue = 0;//Creates variable for card value
            Random rnd = new Random();//Generates a random number

            public List<Cards> playerCards = new List<Cards>();//List for players cards
            public List<Cards> dealerCards = new List<Cards>();//List for dealers cards

            public int PlayerPoints//Returns players points to main method
            {
                get { return playerPoints; }
            }
            public int DealerPoints//Returns dealers points to main method
            {
                get { return dealerPoints; }
            }

            //Creates a multi dimentional array with every cardnumber for every card type
            int[,] cards = new int[,]
            {
                { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 },
                { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 },
                { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 },
                { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 },
            };
            public void DrawCard(bool turn)//Method for picking up the cards
            {
                bool player = turn;//a variale to check if its the users turn
                if (player == true)//Checks if its the players turn
                {
                    int symbol = rnd.Next(0, cards.GetLength(0));//gets a random number from 0 - 3 for the symbol
                    int number = rnd.Next(0, cards.GetLength(1));//Gets a random number from 0 - 12 for the value
                    int cardnumber = cards[symbol, number];//Sets the card number to the random number
                    if (cardnumber > 10)//Checks if its a picture card
                    {
                        cardValue = 10;//Sets the card value to 10
                    }
                    else
                    {
                        cardValue = cardnumber;//If its not a picture card it sets the card value to the card number
                    }
                    //sets the variable to the name of the card
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
                    Cards card = new Cards(cardType, cardValue, cardnumber);//Creates an object
                    playerCards.Add(card);//Adds the card to the list
                    playerPoints += cardValue;//Adds the card value to players points
                }
                else
                {
                    int symbol = rnd.Next(0, cards.GetLength(0));//gets a random number from 0 - 3 for the symbol
                    int number = rnd.Next(0, cards.GetLength(1));//Gets a random number from 0 - 12 for the value
                    int cardnumber = cards[symbol, number];//Sets the card number to the random number
                    if (cardnumber > 10)//Checks if its a picture card
                    {
                        cardValue = 10;//Sets the card value to 10
                    }
                    else
                    {
                        cardValue = cardnumber;//If its not a picture card it sets the card value to the card number
                    }
                    //sets the variable to the name of the card
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
                    Cards card = new Cards(cardType, cardValue, cardnumber);//Creates an object
                    dealerCards.Add(card);//Adds the card to the list
                    dealerPoints += cardValue;//Adds the card value to the dealers points
                }

            }
            public void ShowPlayersCards()
            {
                Console.Clear();//Clears console window
                Console.WriteLine("Players cards: " + playerPoints);//Writes the players points in console
                foreach (Cards c in playerCards)//writes each card from the list in console
                {
                    Console.WriteLine(c);
                }
                //Writes one of the dealers cards in console
                Console.WriteLine("\r\nDealers cards: ");
                Console.WriteLine(dealerCards[0]);
            }
            public void ShowTable()
            {
                Console.Clear();//Clears the console window
                Console.WriteLine("Players cards: " + playerPoints);//writes the players points in console
                foreach (Cards c in playerCards)//writes each card from the list
                {
                    Console.WriteLine(c);
                }
                Console.WriteLine("Dealers cards: " + dealerPoints);//Writes the dealers points in console
                foreach (Cards c in dealerCards)//Writes each card from the list
                {
                    Console.WriteLine(c);
                }
            }

        }
        public struct Cards
        {
            //Instance variables
            private string cardType;
            private int cardValue;
            private int cardNumber;

            //Our constructor
            public Cards(string cardType, int cardValue, int cardNumber)
            {
                this.cardType = cardType;
                this.cardValue = cardValue;
                this.cardNumber = cardNumber;
            }

            //Override string
            public override string ToString()
            {
                if (cardNumber > 10)
                {
                    //Switches the card number with the picture
                    string cardWithPicture = "";
                    switch (cardNumber)
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
                    //Returns the picture
                    return cardType + ":" + cardWithPicture;
                }
                else
                {
                    //Returns the cards number
                    return cardType + ":" + cardNumber;
                }
                return base.ToString();
            }
        }
    }
}
