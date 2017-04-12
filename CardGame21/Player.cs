using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame21
{
    public class Player
    {
        public Hand Hand { get; protected set; } //карты на руках игроков 
        public bool isFirst { get; private set; }

        public Player(bool isFirst)
        {
            this.isFirst = isFirst;
            this.Hand = new Hand();
        }

    }
}
