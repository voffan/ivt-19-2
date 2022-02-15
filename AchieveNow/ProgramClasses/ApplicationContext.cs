using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AchieveNow.Classes;

namespace AchieveNow.ProgramClasses
{
    internal class ApplicationContext : DbContext
    {
        public DbSet<Achievement> Achievements => Set<Achievement>();
        public DbSet<Category> Categories => Set<Category>();
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
            optionsBuilder.UseMySql("server=achievenow.crtrvtxtpali.ap-northeast-2.rds.amazonaws.com;user=admin;password=ldIsSXJJoNtZww690VcW;database=AchieveNowDB;",
                new MySqlServerVersion(new Version(8, 0, 27)));
        }
    }
}
