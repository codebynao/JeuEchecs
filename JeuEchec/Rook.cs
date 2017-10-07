using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuEchec
{
    class Rook : Pieces
    {
        public Rook(Colour colour) : base(colour)
        {
            DisplayName = "Ro." + colour;
        }
    }
}
