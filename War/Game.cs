using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War
{ //[Serializable() ]
    class Game
    {

        private List<Card> p1wardeck;
        private List<Card> p2wardeck;


        public void Turn(ref Deck p1, ref Deck p2, Card p1Card, Card p2Card, out bool war)
        {
            war = false;
            //P1 wins 
            if (p1Card > p2Card)
            {
                Console.WriteLine("Player one wins!");

                WinAdjust(ref p1, ref p2, p1Card, p2Card);
            }

            //P2 wins
            else if(p1Card < p2Card)
            {
                Console.WriteLine("Player two wins! ");

                WinAdjust(ref p2, ref p1, p2Card, p1Card);
            }



            //War -- same number on draw
            else
            {
                war = true;
                Console.WriteLine("**WAR!**");
                Console.WriteLine("");
                //Current cards on board
                p1wardeck = new List<Card>();
                p2wardeck = new List<Card>();

                //add current card to war deck
                p1wardeck.Add(p1Card);
                p2wardeck.Add(p2Card);

                p1.RemoveCard(p1Card);
                p2.RemoveCard(p2Card);
                
                //End loop when cards are not equal or a deck is empty
                while(p1Card==p2Card && !(p2.IsEmpty() || p1.IsEmpty()))
                {
                    //Flip next three cards, compare last one
                    for (int i = 0; i < 3; i++)
                    {
                        //If list has card, add to war deck and remove from normal deck
                        if(!p1.IsEmpty())
                        {
                            p1Card = p1.DrawCard();
                            p1wardeck.Add(p1Card);
                            p1.RemoveCard(p1Card);
                        }

                        if(!p2.IsEmpty())
                        {
                            p2Card = p2.DrawCard();
                            p2wardeck.Add(p2Card);
                            p2.RemoveCard(p2Card);
                        }
                    }

                }

                Console.WriteLine("Player one's war deck: ");
                for (int i = 0; i < p1wardeck.Count; i++)
                {
                    Console.WriteLine(p1wardeck[i]);
                }

                Console.WriteLine("");

                Console.WriteLine("Player two's war deck: ");
                for (int i = 0; i < p2wardeck.Count; i++)
                {
                    Console.WriteLine(p2wardeck[i]);
                }

                Console.WriteLine("");

                //p1 wins war
                if (p1Card > p2Card)
                {
                    Console.WriteLine("Player one wins!");
                    //get own cards back
                    for (int i = 0; i < p1wardeck.Count; i++)
                    {
                        p1.AddCard(p1wardeck[i]);
                    }

                    //take p2's cards
                    for (int i = 0; i < p2wardeck.Count; i++)
                    {
                        p1.AddCard(p2wardeck[i]);
                    }
                }

                //p2 wins war
                else
                {
                    Console.WriteLine("Player two wins!");
                    //get own cards back
                    for (int i = 0; i < p2wardeck.Count; i++)
                    {
                        p2.AddCard(p2wardeck[i]);
                    }

                    //take p1's cards
                    for (int i = 0; i < p1wardeck.Count; i++)
                    {
                        p2.AddCard(p1wardeck[i]);
                    }
                }
            }

            p1.PrintDeck();
            p2.PrintDeck();
        }

        public void DrawCards(ref Deck p1, ref Deck p2, out Card p1Card, out Card p2Card)
        {

            try
            {
                p1Card = p1.DrawCard();
                //p1.RemoveCard(p1Card);
            }

            catch(IndexOutOfRangeException e)
            {
                p1Card = null;
            }

            try
            {
                p2Card = p2.DrawCard();
                //p2.RemoveCard(p2Card);
            }
            catch(IndexOutOfRangeException e)
            {
                p2Card = null;
            }
        }

        public void WinAdjust(ref Deck winDeck, ref Deck loseDeck, Card winCard, Card loseCard)
        {
            winDeck.AddCard(winCard);
            winDeck.AddCard(loseCard);

            winDeck.RemoveCard(winCard);
            loseDeck.RemoveCard(loseCard);
            
        }

        public void GameOver(ref bool gameover)
        {
            gameover = true;
        }

        public void GetWarCards(out List<Card> p1warcards, out List<Card> p2warcards)
        {
            p1warcards = p1wardeck;
            p2warcards = p2wardeck;
        }
    }
}
