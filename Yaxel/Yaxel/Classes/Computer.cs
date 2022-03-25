using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Yaxel.Classes
{
    internal class Computer
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public Status Status { get; set; }

        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual List<Component> Components { get; set; }
        public int ManufacturerId { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
    }
}
