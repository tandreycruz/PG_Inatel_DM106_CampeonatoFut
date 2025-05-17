using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CampeonatoFut_Console;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CampeonatoFut.Shared.Data.BD
{
    public class CampeonatoFutContext : DbContext
    {
        public DbSet<Team> Team { get; set; }
        public DbSet<Player> Player { get; set; }

        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CampeonatoFut_BD;Integrated Security=True;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
