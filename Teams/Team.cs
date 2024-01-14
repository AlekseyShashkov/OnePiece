using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnePiece
{
    public abstract class Team
    {
        [NotNull]
        public string? Name { get; protected set; }
        [NotNull]
        public List<Human>? Сrew { get; protected set; }

        public abstract void Invite(Human human);
    }
}