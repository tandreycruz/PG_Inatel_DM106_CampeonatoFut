using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CampeonatoFut.Shared.Models;

namespace CampeonatoFut_Console
{
    
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Coach { get; set; }

        public Team(string name, string coach)
        {
            Name = name;
            Coach = coach;
        }
        public override string ToString()
        {
            return $@"{Id} - Time: {Name}";
        }

        public virtual ICollection<Player> Players { get; set; } = new List<Player>();

        public virtual ICollection<Stadium> Stadiums { get; set; } = new List<Stadium>();

        public virtual ICollection<Uniform> Uniforms { get; set; } = new List<Uniform>();
                
        public void AddPlayer(Player player)
        {
            Players.Add(player);
        }

        public void AddUniform(Uniform uniform)
        {
            Uniforms.Add(uniform);
        }

        public void ShowPlayers()
        {
            if (Players.Count > 0)
            {
                Console.WriteLine($"\nJogadores do time {Name} ");
                foreach (var Player in Players)
                {
                    Console.WriteLine($"Jogador: {Player.Name} ");
                }
            }
            else
            {
                Console.WriteLine("\nNenhum jogador cadastrado.\n");
            }
        }

        public void ShowUniforms()
        {
            if (Uniforms.Count > 0)
            {
                Console.WriteLine($"\nUniformes do time {Name} ");
                foreach (var Uniform in Uniforms)
                {
                    Console.WriteLine($"Uniforme: {Uniform.Name} ");
                }
            }
            else
            {
                Console.WriteLine("\nNenhum uniforme cadastrado.\n");
            }
        }

    }
}
