using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnePiece
{
    public class Human
    {
        public string Name { get; protected set; }
        public bool IsDevilFruit { get; set; }

        public Human(string name, bool isDevilFruit = false)
        {
            if (name.Length < 1)
            {
                throw new Exception("Human must have a name!");
            }
            Name = name;
            IsDevilFruit = isDevilFruit;
        }

        public virtual void Action()
        {
            Console.WriteLine("Human Action!");
        }
    }
}