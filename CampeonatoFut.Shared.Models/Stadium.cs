using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CampeonatoFut_Console;

namespace CampeonatoFut.Shared.Models
{
    public class Stadium
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public virtual ICollection<Team> Team { get; set; }

        public override string ToString()
        {
            return $@"{Id} - Nome: {Name}";
        }
    }
}
