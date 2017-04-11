using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame21
{
    public class PlayerAI : Player
    {
        public PlayerAI()
        {
            this.Hand = new Hand(isFirst: true);
        }
    }
}
