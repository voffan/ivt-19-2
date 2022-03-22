using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore.ModelConfiguration.Conventions;
using Microsoft.EntityFrameworkCore;
using Hoplits.Classes;

namespace Hoplits
{
    public class Context : DbContext
    {
        public Context() { }

        public DbSet<Employer> Employers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Error> Errors { get; set; }
        public DbSet<Solution> Solutions { get; set; }
    }
}
