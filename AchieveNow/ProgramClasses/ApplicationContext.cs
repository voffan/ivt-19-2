using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AchieveNow.Classes;
using System.Text.Json;
using System.IO;

namespace AchieveNow.ProgramClasses
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Achievement> Achievements => Set<Achievement>();
        public DbSet<Competition> Competitions => Set<Competition>();
        public DbSet<Employee> Employees => Set<Employee>();
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
            FileInfo configurationFile = new FileInfo("ConfigurationDB.json");

            if (configurationFile.Exists)
            {
                var configurationDB = JsonSerializer.Deserialize<ConfigurationDB>(File.ReadAllText(configurationFile.ToString()));

                if (configurationDB != null)
                {
                    if (configurationDB.isRemote)
                    {
                        optionsBuilder.UseMySql($"server={configurationDB?.Server}; user={configurationDB?.User}; password={configurationDB?.Password}; database={configurationDB?.Database};",
                            new MySqlServerVersion(new Version(8, 0, 27)));
                    }
                    else
                    {
                        optionsBuilder.UseSqlite("Data Source=AchieveNowDB.db");
                    }
                }
            }
            else
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true // Добавить визуальную составляющую с пробелами и переносами строки в файле json
                };

                using (FileStream fs = new FileStream(configurationFile.ToString(), FileMode.OpenOrCreate))
                {
                    ConfigurationDB configurationDB = new ConfigurationDB(false);
                    JsonSerializer.Serialize<ConfigurationDB>(fs, configurationDB, options);
                }
            }
        }
    }
}
