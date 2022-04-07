using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Hoplits.Classes;

namespace Hoplits.Cs
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Employer> Employers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Error> Errors { get; set; }
        public DbSet<Solution> Solutions { get; set; }

        public ApplicationContext() : base()
        {
            Database.EnsureCreated();
        }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "server=localhost;user=root;password=123;database=hoplits;",
                new MySqlServerVersion(new Version(8, 0, 28))
            );
        }
    }
}
