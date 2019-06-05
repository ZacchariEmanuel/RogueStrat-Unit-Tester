using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using List_ExtensionMethods;

namespace Unit_Test
{
    public partial class DeckbuilderForm : Form
    {
        const int handsize = 5;
        const int manaperturn= 3;
        //List<Card> Deck;
        List<Card> localDeck;
        List<Card> hand = new List<Card>();
        List<ManaType> Mana = new List<ManaType>() {
            new ManaType(){ name = "Fire", amount = 0},
            new ManaType(){ name = "Water", amount = 0},
            new ManaType(){ name = "Nature", amount = 0},
            new ManaType(){ name = "Air", amount = 0},
            new ManaType(){ name = "Ground", amount = 0},
            new ManaType(){ name = "Dark", amount = 0},
            new ManaType(){ name = "Light", amount = 0}
        };
        Random rdmSeed = new Random(DateTime.Now.Millisecond + DateTime.Now.Day*13 + 3);
        public DeckbuilderForm()
        {
            InitializeComponent();
        }


        private void BtnDraw_Click(object sender, EventArgs e)
        {
            List<Card> handcopy = new List<Card>();
            for (int i = 0; i < hand.Count; i++)
            {
                handcopy.Add(hand[i]);
            }
            
            hand.Clear();
            for (int i = 0; i < handsize; i++)
                hand.Add(localDeck.RemoveRDM(rdmSeed));
            localDeck.AddRange(handcopy.ToArray());
            DrawHand();

            //MANA//
            TakeInMana();

            for (int i = 0; i < manaperturn; i++) {
                Mana[rdmSeed.Next(0, Mana.Count)].amount++;
            }

            DrawMana();
        }

        private void CreateDeck() {
            string[] deckLines = txtDeck.Text.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            localDeck = new List<Card>();
            for (int i = 0; i < deckLines.Length; i++)
                localDeck.Add(new Card() { name = deckLines[i] });
        }

        private void TakeInMana()
        {
            string[] manaLines = txtMana.Text.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            for (int i = 0; i < manaLines.Length; i++) {
                Predicate<ManaType> whereManaTypeMatches = new Predicate<ManaType>(m => m.name[0] == manaLines[i].Split(':')[0].ToCharArray()[0]);
                if (Mana.Exists(whereManaTypeMatches)) {
                    int newamount = 0;
                    int.TryParse(manaLines[i].Split(':')[1], out newamount);
                    Mana.Find(whereManaTypeMatches).amount = newamount;
                }
            }
        }

        private void DrawMana()
        {
            txtMana.Text = "";
            for (int i = 0; i < Mana.Count; i++)
            {
                txtMana.Text += Mana[i].name[0] + ": " + Mana[i].amount;
                if (i + 1 != Mana.Count)
                    txtMana.Text += "\r\n";
            }
        }

        private void DrawHand() {
            txtHand.Text = "";
            txtLocalDeck.Text = "";
            for (int i = 0; i < hand.Count; i++)
            {
                txtHand.Text += hand[i].name;
                if (i != hand.Count - 1)
                    txtHand.Text += "\r\n";
            }

            for (int i = 0; i < localDeck.Count; i++)
            {
                txtLocalDeck.Text += localDeck[i].name;
                if (i != localDeck.Count - 1)
                    txtLocalDeck.Text += "\r\n";
            }
        }

        private void BtnPushDeck_Click(object sender, EventArgs e)
        {
            CreateDeck();
            DrawHand();
        }
    }

    public class Card {
        public string name;
        int[] influence;
    }
    public class ManaType
    {
        public string name;
        public int amount;
    }
}
