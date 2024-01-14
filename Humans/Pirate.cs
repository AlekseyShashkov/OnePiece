using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnePiece
{
    public class Pirate : Human, IBecomePirateKing
    {
        public ulong Bounty { get; set; }
        public bool BecomePirateKing { get; set; }

        public Pirate(string name, ulong bounty, bool isDevilFruit = false)
            : base(name, isDevilFruit)
        {
            if (name.Length < 1)
            {
                throw new Exception("Pirate must have a name!");
            }
            Bounty = bounty;
            BecomePirateKing = true;
        }

        public override void Action()
        {
            Console.WriteLine("Pirate Action!");
        }

        public void Adventure()
        {
            Console.WriteLine("Have fun with friends!");
        }
    }
}