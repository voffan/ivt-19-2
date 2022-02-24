using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AchieveNow.Classes;
using Newtonsoft.Json;
using System.IO;

namespace AchieveNow.ProgramClasses
{
    internal class ApplicationContext : DbContext
    {
        public DbSet<Achievement> Achievements => Set<Achievement>();
        public DbSet<Competition> Competitions => Set<Competition>();
        public DbSet<Employee> Employees => Set<Employee>();
        //public DbSet<Gender> Genders => Set<Gender>();
        //public DbSet<Level> Levels => Set<Level>();
        public DbSet<Location> Locations => Set<Location>();
        public DbSet<Position> Positions => Set<Position>();
        public DbSet<SportKind> SportKinds => Set<SportKind>();
        public DbSet<Sportsman> Sportsmen => Set<Sportsman>();

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = JsonConvert.DeserializeObject<ConfigurationDB>(File.ReadAllText("ConfigurationDB.json"));
            optionsBuilder.UseMySql(configuration.Server + configuration.User + configuration.Password + configuration.Database,
                new MySqlServerVersion(new Version(8, 0, 27)));
        }
    }
}
