<div id="header" align="center">
  <img src="https://github.com/AlekseyShashkov/OnePiece/assets/17510024/845309f0-e503-4f94-a846-125f5dba6780" height="300px" alt="Pokemon Logo"/>
</div>

<h1 align="center"> Применим принципы SOLID чтобы открыть <br/>⚓ Великую Эру Пиратов! ⚓</h1>
<p align="center">
  <img src="https://github.com/AlekseyShashkov/OnePiece/assets/17510024/2f45d900-8fb1-453a-9925-d77c99359daa"/>
</p>

<h2 align="center"> SRP</h2>

&nbsp;&nbsp;<img src="https://github.com/AlekseyShashkov/OnePiece/assets/17510024/788002c4-4912-43bd-8ed0-570f13ba5405" height="35px"/>&nbsp;&nbsp;
Вначале опишим класс `Pirate` и создадим пиратскую команду `PirateTeam` совершающую пиратские дела, а операцию вывода статистической информации
согласно **Принципу единственной обязанности** мы вынесем в отдельный класс `Status`.<br/>
 
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


<p align="center">
  <img src="https://github.com/AlekseyShashkov/OnePiece/assets/17510024/6530cbf0-8dec-41c9-a51e-650cfca09f56"/>
</p>

