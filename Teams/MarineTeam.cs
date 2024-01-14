using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OnePiece
{
    public class MarineTeam : Team
    {
        public MarineTeam(string name)
        {
            Name = name;
            Сrew = [];
        }

        public override void Invite(Human marine)
        {
            Сrew.Add(marine);
        }

        public void Catch()
        {
            Console.WriteLine("Catch the pirates!");
        }
    }
}