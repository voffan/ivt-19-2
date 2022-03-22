using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Hoplits.Classes;

namespace Hoplits.Cs
{
    internal class ApplicationContext : DbContext
    {
        public DbSet<Employer> Employers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Error> Errors { get; set; }
        public DbSet<Solution> Solutions { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "server=localhost;user=root;password=12345678;database=usersdb5;",
                new MySqlServerVersion(new Version(8, 0, 28))
            );
        }
    }
}
