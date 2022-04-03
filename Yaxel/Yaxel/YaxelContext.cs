using System.Data.Entity;

namespace Yaxel
{
    internal class YaxelContext : DbContext
    {
        public YaxelContext() : base ("DefaultConnection")
        {

        }

        public DbSet<Classes.Employee> Employees { get; set; }
        public DbSet<Classes.Computer> Computers { get; set; }
        public DbSet<Classes.Periphery> Peripheries { get; set; }
        public DbSet<Classes.Component> Components { get; set; }
        public DbSet<Classes.Attribute> Attributes { get; set; }
        public DbSet<Classes.Manufacturer> Manufacturers { get; set; }
    }
}
