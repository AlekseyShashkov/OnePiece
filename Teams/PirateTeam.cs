using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OnePiece
{
    public class PirateTeam : Team
    {
        public IMove Mover { get; set; }
        public PirateTeam(string name, IMove mover)
        {
            Name = name;
            Mover = mover;
            Сrew = [];
        }

        public override void Invite(Human pirate)
        {
            Сrew.Add(pirate);
        }

        public void Move()
        {
            Mover.Move();
        }
    }

    public class OnePieceMover : IMove
    {
        public void Move()
        {
            Console.WriteLine("Move towards One Piece!");
        }
    }

    public class FunMover : IMove
    {
        public void Move()
        {
            Console.WriteLine("Move for fun!");
        }
    }
}