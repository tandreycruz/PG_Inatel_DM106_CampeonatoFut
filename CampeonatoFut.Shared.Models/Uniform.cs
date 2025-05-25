using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CampeonatoFut_Console;

namespace CampeonatoFut.Shared.Models
{
    public class Uniform
    {
        public int Id { get; set; }

        public string Name { get; set; }
        

        public virtual Team? Team { get; set; }

        public Uniform(string name)
        {
            Name = name;            
        }
        public override string ToString()
        {
            return $@"Uniforme: {Name}";
        }
    }
}
