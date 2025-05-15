using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampeonatoFut_Console
{
    
    internal class Team
    {
        public string Name { get; set; }
        public string Coach { get; set; }

        public Team(string name, string coach)
        {
            Name = name;
            Coach = coach;
        }
        public override string ToString()
        {
            return $@"Time: {Name}";
        }

        private List<Player> Players = new List<Player>();
        public void AddPlayer(Player player)
        {
            Players.Add(player);
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

    }
}
