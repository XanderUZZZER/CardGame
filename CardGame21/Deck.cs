using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame21
{
    class Deck
    {
        const int CARDS_NUMBER = 36;
        private readonly List<Card> cards = new List<Card>(CARDS_NUMBER);

        public Deck()
        {
            this.Populate();
        }

        public void Populate()
        {
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    this.cards.Add( new Card() { suit = suit, rank = rank });
                }
            }
        }

        public void Shuffle()
        {            
            int i = CARDS_NUMBER - 1;
            Random randomCard = new Random();
            while (i > 0)
            {
                int tempIndex = randomCard.Next(i);
                Card tempCard = this.cards[i];
                this.cards[i] = this.cards[tempIndex];
                this.cards[tempIndex] = tempCard;
                i--;
            }
        }

        public void Deal(Hand hand)
        {
            Card tempCard = this.cards.First();
            hand.AddCard(tempCard);
            this.cards.Remove(tempCard);

            tempCard = this.cards.First();
            hand.AddCard(tempCard);
            this.cards.Remove(tempCard);
        }

        public void GiveAdditionalCard(Hand hand)
        {
            hand.AddCard(this.cards.First());
            this.cards.RemoveAt(0);
        }
    }
}
