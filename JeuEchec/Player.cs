using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuEchec
{
    class Player
    {
        public string name;
        public static List<string> ListPlayers = new List<string>();

        public Player(string name)
        {
            this.name = name;
            ListPlayers.Add(name);
        }        
    }
}
