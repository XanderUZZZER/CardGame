using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame21
{
    class PlayerHuman : Player
    {
        public PlayerHuman()
        {
            this.Hand = new Hand(isFirst: false);
        }
    }
}
