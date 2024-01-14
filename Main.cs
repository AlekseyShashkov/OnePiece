using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace OnePiece
{
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