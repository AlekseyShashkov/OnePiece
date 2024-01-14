using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}