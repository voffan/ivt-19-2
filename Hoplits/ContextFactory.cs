using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;
using Hoplits.Cs;
using Microsoft.EntityFrameworkCore;

namespace Hoplits
{
    public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseMySql(
                "server=localhost;user=root;password=1234;database=hoplits;",
                new MySqlServerVersion(new Version(8, 0, 28))
            );

            return new ApplicationContext(optionsBuilder.Options);
        }
    }
}
