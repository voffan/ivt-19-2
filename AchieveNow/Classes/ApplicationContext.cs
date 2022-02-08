using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AchieveNow.Classes
{
    internal class ApplicationContext : DbContext
    {
        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<SportKind> SportKinds { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Sportsman> Sportsmen { get; set; }
        public DbSet<Competition> Competitions { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Level> Levels { get; set; }
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=achievenow.crtrvtxtpali.ap-northeast-2.rds.amazonaws.com;user=admin;password=ldIsSXJJoNtZww690VcW;database=AchieveNowDB;",
                new MySqlServerVersion(new Version(8, 0, 27)));
        }
    }
}
