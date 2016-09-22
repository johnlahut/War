using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War
{
    
    
    class Card
    {


        //Each card has a suit and a value
        private Suits suit;
        private Values value;


        //Constructors -- one base; three are chained off the OG
        public Card(Suits suit, Values cardVal)
        {
            this.suit = suit;
            this.value = cardVal;
        }

        public Card(Suits suit) : this(suit, Values.DEFAULT) { }

        public Card(Values value) : this(Suits.DEFAULT, value) { }

        public Card() : this(Suits.DEFAULT, Values.DEFAULT) { }



        //Get/Set functions
        public void setSuit(Suits suit)
        { this.suit = suit; }

        public Suits getSuit()
        { return suit; }

        public void setValue(Values value)
        { this.value = value; }

        public Values getValue()
        { return value; }

        public override string ToString()
        {
            return value + " " + suit;
        }

        public static bool operator<(Card c1, Card c2)
        {
            if (c1.getValue() < c2.getValue())
                return true;
            return false;
        }

        public static bool operator>(Card c1, Card c2)
        {
            return c1.getValue() > c2.getValue();
        }

        public static bool operator==(Card c1, Card c2)
        {
            return c1.getValue() == c2.getValue();
        }

        public static bool operator !=(Card c1, Card c2)
        {
            return !(c1 == c2);
        }
        
    }
}
