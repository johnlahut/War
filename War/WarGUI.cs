using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace War
{
    public partial class WarGUI : Form
    {

        

        Game game = new Game();

        Deck p1;
        Deck p2;

        PictureBox[] p1WarPbxArr;
        PictureBox[] p2WarPbxArr;

        public WarGUI()
        {
            InitializeComponent();
            warLbl.Hide();
            NewGame();
            Refresh();
        }

        private void flipCards_Click(object sender, EventArgs e)
        {
            bool war;
            Card p1CurrCard, p2CurrCard;
            warLbl.Hide();

            game.DrawCards(ref p1, ref p2, out p1CurrCard, out p2CurrCard);

            UpdateCards(p1CurrCard, p2CurrCard);

            game.Turn(ref p1, ref p2, p1CurrCard, p2CurrCard, out war);

            if(war)
            {
                List<Card> p1warcards, p2warcards;

                game.GetWarCards(out p1warcards, out p2warcards);


                for (int i = 0; i < p1warcards.Count; i++)
                {
                }

                


                p1war11Pbx.Load(GetCardImageString(p1warcards[1]));
                p2war11Pbx.Load(GetCardImageString(p2warcards[1]));

                p1war12Pbx.Load(GetCardImageString(p1warcards[2]));
                p2war12Pbx.Load(GetCardImageString(p2warcards[2]));

                p1war13Pbx.Load(GetCardImageString(p1warcards[3]));
                p2war13Pbx.Load(GetCardImageString(p2warcards[3]));

                warLbl.Show();
            }

            //warLbl.Hide();
            Refresh();

            if(p2.IsEmpty())
            {
                DialogResult newgame = MessageBox.Show("Player one wins! New Game?", "Game Over", MessageBoxButtons.YesNo);
                if (newgame == DialogResult.Yes)
                {
                    System.Windows.Forms.Application.Restart();
                }

                else
                {
                    flipCards.Enabled = false;
                }
            }

            else if(p1.IsEmpty())
            {
                DialogResult newgame = MessageBox.Show("Player two wins! New Game?", "Game Over", MessageBoxButtons.YesNo);
                if (newgame == DialogResult.Yes)
                {
                    System.Windows.Forms.Application.Restart();
                }

                else
                {
                    flipCards.Enabled = false;
                }
            }
        }

        private void UpdateCards(Card p1CurrCard, Card p2CurrCard)
        {
            p1CardPbx.Load(GetCardImageString(p1CurrCard));
            p2CardPbx.Load(GetCardImageString(p2CurrCard));

            p1CardPbx.SizeMode = PictureBoxSizeMode.StretchImage;
            p2CardPbx.SizeMode = PictureBoxSizeMode.StretchImage;

        }

        private void p1Cards_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Refresh()
        {

            p1Cards.Items.Clear();
            p2Cards.Items.Clear();

            string[] p1card_string = p1.DeckToStringArr();
            string[] p2card_string = p2.DeckToStringArr();



            for (int i = 0; i < p1card_string.Length; i++)
            {
                p1Cards.Items.Add(p1card_string[i]);
            }

            for (int i = 0; i < p2card_string.Length; i++)
            {
                p2Cards.Items.Add(p2card_string[i]);
            }
        }

        private string GetCardImageString(Card card)
        {
            string imglink = "";

            imglink = (int)card.getValue() + "_of_" + card.getSuit().ToString().ToLower() + ".png";

            return imglink;
        }

        public void NewGame()
        {
            p1 = new Deck();
            p2 = new Deck();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void p2CardPbx_Click(object sender, EventArgs e)
        {

        }


    }
}
