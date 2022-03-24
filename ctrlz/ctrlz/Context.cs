using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;
using ctrlz.Classes;

namespace ctrlz
{

    public class Context : DbContext
    {
        public Context() : base("Mysql") { }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Employee> Employees { get; set; }


    }
}