using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnePiece
{
    public class Status
    {
        public void Print(Team team)
        {
            Console.WriteLine($"{team.Name}:");

            foreach (var human in team.Сrew)
            {
                Console.WriteLine($"{human.Name}");
            }
            Console.WriteLine("");
        }
    }
}