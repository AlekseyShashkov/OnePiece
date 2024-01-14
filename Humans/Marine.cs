using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnePiece
{
    public class Marine : Human, IJustice
    {
        public Personnel Rank { get; set; }
        public bool IsJustice { get; set; }

        public Marine(string name, Personnel rank, bool isDevilFruit = false)
            : base(name, isDevilFruit)
        {
            if (name.Length < 1)
            {
                throw new Exception("Marine must have a name!");
            }
            Rank = rank;
            IsJustice = true;
        }

        public override void Action()
        {
            Console.WriteLine("Marine Action!");
        }

        public void Adventure()
        {
            Console.WriteLine("Maintain order!");
        }
    }

    public enum Personnel : byte
    {
        FleetAdmiral,
        Admiral,
        ViceAdmiral,
        RearAdmiral,
        Captain
    }
}