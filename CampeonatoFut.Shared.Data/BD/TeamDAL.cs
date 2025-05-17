using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CampeonatoFut_Console;
using Microsoft.Data.SqlClient;

namespace CampeonatoFut.Shared.Data.BD
{
    public class TeamDAL
    {
        private readonly CampeonatoFutContext context;
        public TeamDAL()
        {
            context = new CampeonatoFutContext();
        }
        public void Create(Team team)
        {
            context.Set<Team>().Add(team);
            context.SaveChanges();
        }

        public void Update(Team team)
        {
            context.Team.Update(team);
            context.SaveChanges();
        }

        public void Delete(Team team)
        {
            context.Team.Remove(team);
            context.SaveChanges();
        }

        public IEnumerable<Team> Read()
        {
            return context.Team.ToList();
        }

        public Team? ReadByName(string name)
        {
            return context.Team.FirstOrDefault(x => x.Name == name);
        }
    }
}
