﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampeonatoFut_Console
{
    public class Player
    {
        public int Id { get; set; }

        public string Name { get; set; }        

        public virtual Team? Team { get; set; }

        public Player(string name)
        {
            Name = name;            
        }
        public override string ToString()
        {
            return $@"Jogador: {Name}";
        }
    }
}
