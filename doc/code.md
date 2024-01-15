```csharp
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace OnePiece
{
    public interface IAdventure
    {
        public void Adventure();
    }

    public interface IJustice : IAdventure
    {
        public bool IsJustice { get; set; }
    }

    public interface IBecomePirateKing : IAdventure
    {
        public bool BecomePirateKing { get; set; }
    }

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

    public abstract class Team
    {
        [NotNull]
        public string? Name { get; protected set; }
        [NotNull]
        public List<Human>? Сrew { get; protected set; }

        public abstract void Invite(Human human);
    }

    public interface IMoveForward
    {
        public void MoveForward();
    }

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

    public class MainClass
    {
        public static void Main(string[] args)
        {
            MarineTeam marines = new("Marines");
            marines.Invite(new Marine("Sakazuki", Personnel.FleetAdmiral, true));
            marines.Invite(new Marine("Kizaru", Personnel.Admiral, true));
            marines.Invite(new Marine("Monkey D. Garp", Personnel.ViceAdmiral));
            marines.Invite(new Marine("Momonga", Personnel.ViceAdmiral));
            marines.Invite(new Marine("Hina", Personnel.RearAdmiral));
            marines.Invite(new Marine("Tashigi", Personnel.Captain));

            PirateTeam strawHats = new("Straw Hat Pirates", new FunMover());
            strawHats.Invite(new Pirate("Monkey D. Luffy", 3000000000L, true));
            strawHats.Invite(new Pirate("Roronoa Zoro", 1111000000L));
            strawHats.Invite(new Pirate("Nami", 366000000L));
            strawHats.Invite(new Pirate("God Usopp", 500000000L));
            strawHats.Invite(new Pirate("Sanji", 1032000000L));
            strawHats.Invite(new Pirate("Tony Tony Chopper", 1000L, true));
            strawHats.Invite(new Pirate("Nico Robin", 930000000L, true));
            strawHats.Invite(new Pirate("Franky", 394000000L));
            strawHats.Invite(new Pirate("Brook", 383000000L, true));

            Status status = new();
            status.Print(marines);
            status.Print(strawHats);

            strawHats.Move();
            strawHats.Mover = new OnePieceMover();
            strawHats.Move();
        }
    }
}
```