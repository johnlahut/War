using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace War
{
    class Program
    {
        static void Main(string[] args)
        {
            //Card c1, c2;

            Application.Run(new WarGUI());

            Game game = new Game();

            Deck p1 = new Deck();
            Deck p2 = new Deck();

            p1.PrintDeck();
            p2.PrintDeck();

            //Console.WriteLine(p1.Length());

            ConsoleKeyInfo key = Console.ReadKey();

            bool gameover = false;

            //while (key.Key == ConsoleKey.Y && !gameover)
            //{
            //    game.Turn(ref p1, ref p2);
            //    if (p1.IsEmpty() || p2.IsEmpty())
            //    {
            //        game.GameOver(ref gameover);
            //    }

            //    key = Console.ReadKey();
            //}


        }

        

        
    }
}
