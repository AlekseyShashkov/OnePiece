<div id="header" align="center">
  <img src="https://github.com/AlekseyShashkov/OnePiece/assets/17510024/845309f0-e503-4f94-a846-125f5dba6780" height="300px" alt="Pokemon Logo"/>
</div>

<h1 align="center"> Применим принципы SOLID чтобы открыть <br/>⚓ Великую Эру Пиратов! ⚓</h1>
<p align="center">
  <img src="https://github.com/AlekseyShashkov/OnePiece/assets/17510024/2f45d900-8fb1-453a-9925-d77c99359daa"/>
</p>

<h2 align="center"> SRP</h2>

&nbsp;&nbsp;<img src="https://github.com/AlekseyShashkov/OnePiece/assets/17510024/788002c4-4912-43bd-8ed0-570f13ba5405" height="35px"/>&nbsp;&nbsp;
Вначале опишим класс `Pirate` и создадим пиратскую команду `PirateTeam` которая совершает пиратские дела, а операцию вывода статистической информации
согласно **Принципу единственной обязанности** мы вынесем в отдельный класс `Status`:<br/>
 
<img src="https://github.com/AlekseyShashkov/OnePiece/assets/17510024/e82663e4-4cc8-4d9c-a30f-31dfc26d73b1" align="left"/> 

```csharp
    public class Pirate(string name, ulong bounty, bool isDevilFruit = false)
    {
        public string Name { get; } = name;
        public ulong Bounty { get; set; } = bounty;
        public bool IsDevilFruit { get; set; } = isDevilFruit;

        public void Action()
        {
            Console.WriteLine("Pirate Action!");
        }
    }

    public class PirateTeam(string name)
    {
        public string Name { get; } = name;
        public List<Pirate> Crew { get; } = [];

        public void Invite(Pirate pirate)
        {
            Crew.Add(pirate);
        }

        public void Move()
        {
            Console.WriteLine("Move towards One Piece!");
        }
    }

    public class Status
    {
        public void Print(PirateTeam team)
        {
            Console.WriteLine($"{team.Name}:");

            ulong bounty = 0L;

            foreach (var pirate in team.Crew)
            {
                Console.Write($"{pirate.Name}");
                Console.WriteLine($" - {pirate.Bounty}");
                bounty += pirate.Bounty;
            }
            Console.WriteLine($" -Team bounty: {bounty}- ");
            Console.WriteLine("");
        }
    }
```

<details><summary>Результат работы</summary>  
<img src="https://github.com/AlekseyShashkov/OnePiece/assets/17510024/97a3a139-393e-449d-985c-71567cb11b05" align="left"/> 

```csharp
    public class MainClass
    {
        public static void Main(string[] args)
        {
            PirateTeam noNames = new("No Names");
            noNames.Invite(new Pirate("Crook #1", 10000L));
            noNames.Invite(new Pirate("Crook #2", 20000L));
            noNames.Invite(new Pirate("Crook #3", 25000L));

            PirateTeam strawHats = new("Straw Hat Pirates");
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
            status.Print(noNames);
            status.Print(strawHats);

            strawHats.Move();
        }
    }
```
</details>
<hr/>

&nbsp;&nbsp;<img src="https://github.com/AlekseyShashkov/OnePiece/assets/17510024/788002c4-4912-43bd-8ed0-570f13ba5405" height="35px"/>&nbsp;&nbsp;
UML-схема классов выглядит следующим образом:
<p align="center">
  <img src="https://github.com/AlekseyShashkov/OnePiece/assets/17510024/6530cbf0-8dec-41c9-a51e-650cfca09f56" width="40%"/>
</p>

📘 [<i>Принцип единственной обязанности (Single Responsibility Principle)</i>](https://metanit.com/sharp/patterns/5.1.php)

<h2 align="center"> OCP</h2>

&nbsp;&nbsp;<img src="https://github.com/AlekseyShashkov/OnePiece/assets/17510024/788002c4-4912-43bd-8ed0-570f13ba5405" height="35px"/>&nbsp;&nbsp;
В мире One Piece живут не только пираты, да и пиратом не рождаются, а становятся. Поэтому согласно **Принципу открытости/закрытости** опишим класс `Human`,
воспользуемся паттерном Шаблонный метод для описания архитектуры команд `Team` и зададим представителей морского дозора в `Marine` и `MarineTeam`:<br/>

<img src="https://github.com/AlekseyShashkov/OnePiece/assets/17510024/fe0da5b5-c1f8-4fe8-9bce-4b7a580d1666" align="left"/> 

```csharp
    public class Human(string name, bool isDevilFruit = false)
    {
        public string Name { get; protected set; } = name;
        public bool IsDevilFruit { get; set; } = isDevilFruit;

        public virtual void Action()
        {
            Console.WriteLine("Human Action!");
        }
    }

    public class Pirate(string name, ulong bounty, bool isDevilFruit = false) 
        : Human(name, isDevilFruit)
    {
        public ulong Bounty { get; set; } = bounty;

        public override void Action()
        {
            Console.WriteLine("Pirate Action!");
        }
    }

    public class Marine(string name, Personnel rank, bool isDevilFruit = false) 
        : Human(name, isDevilFruit)
    {
        public Personnel Rank { get; set; } = rank;

        public override void Action()
        {
            Console.WriteLine("Marine Action!");
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

    public class PirateTeam : Team
    {
        public PirateTeam(string name)
        {
            Name = name;
            Сrew = [];
        }

        public override void Invite(Human pirate)
        {
            Сrew.Add(pirate);
        }

        public void Move()
        {
            Console.WriteLine("Move towards One Piece!");
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
```
<details><summary>Результат работы</summary>  
<img src="https://github.com/AlekseyShashkov/OnePiece/assets/17510024/1bc15d9f-27b9-44f6-b2ba-39a0fcd9383b" align="left"/> 

```csharp
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

            PirateTeam strawHats = new("Straw Hat Pirates");
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
        }
    }
```
</details>
<hr/>

&nbsp;&nbsp;<img src="https://github.com/AlekseyShashkov/OnePiece/assets/17510024/788002c4-4912-43bd-8ed0-570f13ba5405" height="35px"/>&nbsp;&nbsp;
UML-схема классов выглядит следующим образом:
<p align="center">
  <img src="https://github.com/AlekseyShashkov/OnePiece/assets/17510024/351dd4b6-6822-4b5d-9959-dc45b1bfb6a4" width="80%"/>
</p>

📕 [<i>Принцип открытости/закрытости (Open/Closed Principle)</i>](https://metanit.com/sharp/patterns/5.2.php)

<h2 align="center"> OCP</h2>

