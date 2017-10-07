using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuEchec
{
    class Bishop : Pieces
    {
        public Bishop(Colour colour) : base(colour)
        {
            DisplayName = "Bi." + colour;
        }
    }
}
