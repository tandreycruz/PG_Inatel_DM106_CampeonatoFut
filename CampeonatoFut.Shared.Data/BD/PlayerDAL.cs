using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CampeonatoFut_Console;

namespace CampeonatoFut.Shared.Data.BD
{
    public class PlayerDAL
    {
        private readonly CampeonatoFutContext context;
        public PlayerDAL()
        {
            context = new CampeonatoFutContext();
        }
        public void Create(Player player)
        {
            context.Set<Player>().Add(player);
            context.SaveChanges();
        }

        public void Update(Player player)
        {
            context.Player.Update(player);
            context.SaveChanges();
        }

        public void Delete(Player player)
        {
            context.Player.Remove(player);
            context.SaveChanges();
        }

        public IEnumerable<Player> Read()
        {
            return context.Player.ToList();
        }

        public Player? ReadByName(string name)
        {
            return context.Player.FirstOrDefault(x => x.Name == name);
        }
    }
}
