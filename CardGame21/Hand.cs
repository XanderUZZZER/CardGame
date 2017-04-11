using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame21
{
    public class Hand
    {
        private readonly List<Card> cards = new List<Card>(5);
        public bool IsFirst { get; private set; }

        public Hand(bool isFirst = false)
        {
            this.IsFirst = isFirst;
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
