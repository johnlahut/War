using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War
{
    
    enum Suits {DEFAULT, SPADES, CLUBS, DIAMONDS, HEARTS};
    enum Values {DEFAULT, ACE, TWO, THREE, FOUR, FIVE, SIX, SEVEN, EIGHT, NINE, TEN, JACK, QUEEN, KING};

    class Deck
    {

        const int NUM_SUITS = 2;
        const int NUM_CARDS_EACH_SUIT = 5;


        private Random rand;
        private List<Card> deck;

        public Deck(bool shuffled = true)
        {
            Suits suits = Suits.SPADES;
            Values values = Values.ACE;

            deck = new List<Card>();

            rand = new Random((int)DateTime.Now.Ticks);

            if (!shuffled)
            {
                for (int i = 0; i < NUM_SUITS; i++)
                {
                    values = Values.ACE;

                    for (int j = 0; j < NUM_CARDS_EACH_SUIT; j++)
                    {
                        deck.Add(new Card(suits, values));
                        values++;
                    }

                    suits++;
                }
            }

            else
            {
                List<int> tempArr = new List<int>();
                int currpos;

                for (int i = 0; i < NUM_CARDS_EACH_SUIT * NUM_SUITS; i++)
                {

                    currpos = rand.Next(1, NUM_CARDS_EACH_SUIT * NUM_SUITS);
                    if (!tempArr.Contains(currpos))
                        tempArr.Add(currpos);
                    else
                    {
                        currpos = rand.Next(0, NUM_CARDS_EACH_SUIT * NUM_SUITS);

                        while (tempArr.Contains(currpos))
                            currpos = rand.Next(0, NUM_CARDS_EACH_SUIT * NUM_SUITS);

                        tempArr.Add(currpos);
                    }
                }

                Card[] tempdeck = new Card[NUM_CARDS_EACH_SUIT * NUM_SUITS];
                currpos = 0;
                for (int i = 0; i < NUM_SUITS; i++)
                {

                    values = Values.ACE;

                    for (int j = 0; j < NUM_CARDS_EACH_SUIT; j++)
                    {
                        tempdeck[tempArr[currpos]] = new Card(suits, values);
                        values++;
                        currpos++;
                    }
                    suits++;
                }


                foreach (Card card in tempdeck)
                    deck.Add(card);


            }
        }
    


        public void PrintDeck()
        {
            Console.WriteLine("**CURRENT DECK**");
            for (int i = 0; i < deck.Count; i++)
            { Console.WriteLine(deck[i].getValue() + " of " + deck[i].getSuit()); }
            Console.WriteLine();
        }

        public bool RemoveCard(Card card)
        {
            if (deck.Contains(card))
            {
                deck.Remove(card);
                return true;
            }

            return false;

        }

        public void AddCard(Card card)
        {
            deck.Add(card);
        }

        public bool ContainsCard(Card card)
        { 
            
            return deck.Contains(card);
        }

        public Card DrawCard(bool shuffle = false)
        {
            if (shuffle)
                return deck[rand.Next(0, Length())];
            else
                return deck[0];
        }

        public bool IsEmpty()
        {
            return (deck.Count == 0);
        }

        public int Length()
        {
            return deck.Count;
        }

        public string[] DeckToStringArr()
        {
            string[] stringDeck = new string[deck.Count];

            for (int i = 0; i < deck.Count; i++)
            {
                stringDeck[i] = deck[i].getValue() + " of " + deck[i].getSuit();
            }


            return stringDeck;
        }


    }
}
