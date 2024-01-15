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
        public IMoveForward Mover { get; set; }
        public PirateTeam(string name, IMoveForward mover)
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
            Mover.MoveForward();
        }
    }

    public class OnePieceMover : IMoveForward
    {
        public void MoveForward()
        {
            Console.WriteLine("Move towards One Piece!");
        }
    }

    public class FunMover : IMoveForward
    {
        public void MoveForward()
        {
            Console.WriteLine("Move for fun!");
        }
    }
}