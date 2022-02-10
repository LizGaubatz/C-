using System;
using System.Collections.Generic;

namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start of the Deck of Cards app!");

            Deck CardDeck = new Deck();
            CardDeck.Shuffle();
            Player liz = new Player("ian");
            liz.Draw(CardDeck);
            liz.Draw(CardDeck);
            liz.Discard(5);
            liz.Discard(8);
        }

        class Card
        {
            public string StringVal;
            public int Value;
            public string Suit;
            public static string[] SuitsArray = new string[] { "Hearts", "Diamonds", "Clubs", "Spades"};

            public Card(int val, string suit){
                Value = val;
                Suit = suit;
            }

            public Card(string input){
                switch (Value)
                {
                    case 1:
                        StringVal = "Ace";
                        break;
                    case 11:
                        StringVal = "Jack";
                        break;
                    case 12:
                        StringVal = "Queen";
                        break;
                    case 13:
                        StringVal = "King";
                        break;
                    default:
                        StringVal = Value.ToString();
                        break;
                }
            }
        }

        class Deck
        {
            public  List<Card> Cards;

            public Deck(){
                CreateDeck();
            }

            private List<Card> CreateDeck(){
                Cards = new List<Card>();
                foreach (string suit in Card.SuitsArray){
                    for(int i = 1; i <= 13; i++) {
                        Cards.Add(new Card(i, suit));
                    }
                }
                return Cards;
            }

            public void  ResetDeck(){
                Cards = CreateDeck();
            }

            public Card Deal(){
                if(Cards.Count == 0) return null;
                Card dealtCard = Cards[0];
                Cards.Remove(Cards[0]);
                return dealtCard;
            }

            public void Shuffle(){
                Random rand = new Random();
                Card temp;
                for (int i = 0; i < Cards.Count; i++){
                    int pH = rand.Next(0,51);
                    temp = Cards[i];
                    Cards[i] = Cards[pH];
                    Cards[pH] = temp;
                    }
            }
        };


        class Player
        {
            public string Name;

            public List<Card> Hand = new List<Card>();

            public Player(string name) {
                Name = name;
            }


            public Card Draw(Deck gameDeck){
                Card newCard = gameDeck.Deal();
                Hand.Add(newCard);
                return newCard;
            }

            public Card RemoveCard(List<Card> cards, int cardSpot = 0){
                Card result = cards[cardSpot];
                cards.Remove(result);
                return result;
            }

            public Card Discard(int cardSpot){
                if(Hand.Count > cardSpot) {
                    return RemoveCard(Hand, cardSpot);
                }else{
                    return null;
                }
            }
        }
    }
}
