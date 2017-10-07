using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuEchec
{
    class Knight : Pieces
    {
        public Knight(Colour colour) : base(colour)
        {
            DisplayName = "Kn." + colour;
        }
    }
}
