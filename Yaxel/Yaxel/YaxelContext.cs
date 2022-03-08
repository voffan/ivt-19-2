using System;
using Yaxel.Classes;
using System.Data.Entity;

namespace Yaxel
{
    internal class YaxelContext : DbContext
    {
        public YaxelContext() : base ("DefaultConnection")
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Computer> Computers { get; set; }
        public DbSet<Periphery> Peripheries { get; set; }
        public DbSet<Component> Components { get; set; }
        public DbSet<Classes.Attribute> Attributes { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
    }
}
