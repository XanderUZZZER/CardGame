using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame21
{
    public abstract class Player
    {
        protected Player()
        {                
        }

        public Hand Hand { get; protected set; }

    }
}
