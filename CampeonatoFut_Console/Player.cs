using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampeonatoFut_Console
{
    internal class Player
    {
        public string Name { get; set; }
        public string Position { get; set; }

        public Player(string name, string position)
        {
            Name = name;
            Position = position;
        }
        public override string ToString()
        {
            return $@"Jogador: {Name}";
        }
    }
}
