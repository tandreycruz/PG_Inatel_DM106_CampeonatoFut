using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CampeonatoFut.Shared.Data.Models;
using CampeonatoFut.Shared.Models;
using CampeonatoFut_Console;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CampeonatoFut.Shared.Data.BD
{
    public class CampeonatoFutContext : IdentityDbContext<AccessUser, AccessRole, int>
    {
        public DbSet<Team> Team { get; set; }
        public DbSet<Player> Player { get; set; }
        public DbSet<Stadium> Stadium { get; set; }
        public DbSet<Uniform> Uniform { get; set; }


        //private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CampeonatoFut_BD_V1;Integrated Security=True;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        private string connectionString = "Server=tcp:campeonatofutserver.database.windows.net,1433;Initial Catalog=CampeonatoFut_BD_V1;Persist Security Info=False;User ID=tandreycruz;Password={YourPassword};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString).UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Team>().HasMany(c => c.Stadiums).WithMany(c => c.Team);
        }

    }
}
