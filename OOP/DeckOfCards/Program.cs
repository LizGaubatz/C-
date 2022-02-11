using System;
using System.Collections.Generic;

namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {

// TESTING __________________________________>

            // Card testCard = new Card("Queen", "Hearts", 12);
            // Card testCard2 = new Card()
            // {
            //     Name = "Queen",
            //     Suite = "Hearts",
            //     Value = 12
            // };
            // Deck deck = new Deck();
            // Player player = new Player("Test Dude");
            // deck.Print();
            // deck.Shuffle();
            // Console.WriteLine(deck.Deal());
            // Console.WriteLine(deck.Deal());
            // Console.WriteLine(deck.Deal());

            // Console.WriteLine(player.Draw(deck));
            // Console.WriteLine(player.Draw(deck));
            // Console.WriteLine(player.Draw(deck));
            // Console.WriteLine(player.Hand.Count);
            // Console.WriteLine(player.Discard(0));
            // Console.WriteLine(player.Hand.Count);
        }


// CARD CLASS__________________________________>

    public class Card
    {
        public string Name { get; set; }
        public string Suit { get; set; }
        public int Value { get; set; }
        public Card() { }
        public Card(string name, string suit, int value)
        {
            Name = name;
            Suit = suit;
            Value = value;
        }
        public override string ToString()
        {
            return $@"
        Name:  {Name} 
        Suite: {Suit}
        Value: {Value}";
        }



// DECK CLASS __________________________________>

public class Deck
    {
        public List<Card> Cards { get; set; } = new List<Card>();
        public Deck()
        {
            Reset();
        }
        public Deck Reset()
        {
            Cards = new List<Card>();
            string[] suits =
            {
                "Hearts",
                "Diamonds",
                "Spades",
                "Clubs"
            };
            Dictionary<int, string> faceCardNames = new Dictionary<int, string>()
            {
                { 1, "Ace" },
                { 11, "Jack" },
                { 12, "Queen" },
                { 13, "King" },
            };
            foreach (string suit in suits)
            {
                for (int i = 1; i < 14; i++)
                {
                    string name = i.ToString();
                    if (faceCardNames.ContainsKey(i))
                    {
                        name = faceCardNames[i];
                    }
                    Card card = new Card(name, suit, i);
                    Cards.Add(card);
                }
            }
            return this;
        }

        public Card Deal()
        {
            if (Cards.Count > 0)
            {
                Card topCard = Cards[Cards.Count - 1];
                Cards.RemoveAt(Cards.Count - 1);
                return topCard;
            }
            return null;
        }

        public Deck Shuffle()
        {
            Random random = new Random();
            for (int i = 0; i < Cards.Count; i++)
            {
                int randomIndex = random.Next(Cards.Count);
                Card temp = Cards[i];
                Cards[i] = Cards[randomIndex];
                Cards[randomIndex] = temp;
            }
            return this;
        }

        public void Print()
        {
            string printableDeck = "";
            foreach (Card card in Cards)
            {
                // Since printableDeck is a string when we += card C# knows
                // to execute the card's ToString method.
                printableDeck += card + "\n";
            }
            Console.WriteLine(printableDeck);
        }
    }
}

// PLAYER CLASS __________________________________>

public class Player
    {
        public string Name { get; set; }
        public List<Card> Hand { get; set; } = new List<Card>();
        public Player(string name)
        {
            Name = name;
        }

        public Card Draw(Deck deck)
        {
            Card dealtCard = deck.Deal();
            if (dealtCard != null)
            {
                Hand.Add(dealtCard);
            }
            return dealtCard;
        }
        public Card Discard(int i)
        {
            if (i < 0 || i >= Hand.Count)
            {
                return null;
            }
            Card cardToRemove = Hand[i];
            Hand.Remove(cardToRemove);
            return cardToRemove;
        }
    }
}




// OLD CODE BELOW __________________________________>



            // Deck CardDeck = new Deck();
            // CardDeck.Shuffle();
            // Player liz = new Player("liz");
            // liz.Draw(CardDeck);
            // liz.Draw(CardDeck);
            // liz.Discard(5);
            // liz.Discard(8);

        // class Card
        // {
        //     public string StringVal;
        //     public int Value;
        //     public string Suit;
        //     public static string[] SuitsArray = new string[] { "Hearts", "Diamonds", "Clubs", "Spades"};

        //     public Card(int val, string suit){
        //         Value = val;
        //         Suit = suit;
        //     }

        //     public Card(string input){
        //         switch (Value)
        //         {
        //             case 1:
        //                 StringVal = "Ace";
        //                 break;
        //             case 11:
        //                 StringVal = "Jack";
        //                 break;
        //             case 12:
        //                 StringVal = "Queen";
        //                 break;
        //             case 13:
        //                 StringVal = "King";
        //                 break;
        //             default:
        //                 StringVal = Value.ToString();
        //                 break;
        //         }
        //     }
        // }

        // class Deck
        // {
        //     public  List<Card> Cards;

        //     public Deck(){
        //         CreateDeck();
        //     }

        //     private List<Card> CreateDeck(){
        //         Cards = new List<Card>();
        //         foreach (string suit in Card.SuitsArray){
        //             for(int i = 1; i <= 13; i++) {
        //                 Cards.Add(new Card(i, suit));
        //             }
        //         }
        //         Console.WriteLine("CD Created");
        //         return Cards;
        //     }

        //     public void  ResetDeck(){
        //         Cards = CreateDeck();
        //     }

        //     public Card Deal(){
        //         if(Cards.Count == 0) return null;
        //         Card dealtCard = Cards[0];
        //         Cards.Remove(Cards[0]);
        //         return dealtCard;
        //     }

        //     public void Shuffle(){
        //         Random rand = new Random();
        //         Card temp;
        //         for (int i = 0; i < Cards.Count; i++){
        //             int pH = rand.Next(0,51);
        //             temp = Cards[i];
        //             Cards[i] = Cards[pH];
        //             Cards[pH] = temp;
        //             }
        //         Console.WriteLine("Shuffled");
        //     }
        // };


        // class Player
        // {
        //     public string Name;

        //     public List<Card> Hand = new List<Card>();

        //     public Player(string name) {
        //         Name = name;
        //     }


        //     public Card Draw(Deck gameDeck){
        //         Card newCard = gameDeck.Deal();
        //         Hand.Add(newCard);
        //         return newCard;
        //         Console.WriteLine(newCard);
        //     }

        //     public Card RemoveCard(List<Card> cards, int cardSpot = 0){
        //         Card result = cards[cardSpot];
        //         cards.Remove(result);
        //         return result;
        //     }

        //     public Card Discard(int cardSpot){
        //         if(Hand.Count > cardSpot) {
        //             return RemoveCard(Hand, cardSpot);
        //         }else{
        //             return null;
        //         }
}
