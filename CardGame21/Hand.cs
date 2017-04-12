using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame21
{
    public class Hand
    {
        private readonly List<Card> cards = new List<Card>(2);

        public ReadOnlyCollection<Card> Cards
        {
            get { return this.cards.AsReadOnly(); }
        }

        public int TotalValue()
        {
            int TotalValue = 0;
            foreach (Card card in cards)
                TotalValue += (int)card.rank;
            return TotalValue;
        }

        public void AddCard(Card card)
        {
            this.cards.Add(card);
        }

        public void Clear()
        {
            this.cards.Clear();
        }
    }
}
