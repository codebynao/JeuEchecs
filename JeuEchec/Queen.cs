using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuEchec
{
    class Queen : Pieces
    {
        public Queen(Colour colour) : base(colour)
        {
            DisplayName = "Qu." + colour;
        }
    }
}
