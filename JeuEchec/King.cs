using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuEchec
{
    class King : Pieces
    {
        public King(Colour colour) : base(colour)
        {
            DisplayName = "Ki." + colour;
        }
    }
}
