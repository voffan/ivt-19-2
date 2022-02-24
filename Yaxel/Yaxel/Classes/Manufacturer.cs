using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Yaxel.Classes
{
    internal class Manufacturer
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual List<Computer> Computers { get; set; }
        public virtual List<Periphery> Peripheries { get; set; }
    }
}
