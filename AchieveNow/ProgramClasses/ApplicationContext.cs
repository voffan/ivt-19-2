using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AchieveNow.Classes;
using Newtonsoft.Json;
using System.IO;
using Microsoft.EntityFrameworkCore.Design;

namespace AchieveNow.ProgramClasses
{
    public class ApplicationContext : DbContext
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

        public ApplicationContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = JsonConvert.DeserializeObject<ConfigurationDB>(File.ReadAllText("ConfigurationDB.json"));
            optionsBuilder.UseMySql(configuration.Server + configuration.User + configuration.Password + configuration.Database,
                new MySqlServerVersion(new Version(8, 0, 27)));
        }

    }

    public class BloggingContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            //var configuration = JsonConvert.DeserializeObject<ConfigurationDB>(File.ReadAllText("ConfigurationDB.json"));
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseMySql("server=achievenow.crtrvtxtpali.ap-northeast-2.rds.amazonaws.com;user=admin;password=ldIsSXJJoNtZww690VcW;database=AchieveNowDB;",
                new MySqlServerVersion(new Version(8, 0, 27)));

            return new ApplicationContext(optionsBuilder.Options);
        }
    }
}
