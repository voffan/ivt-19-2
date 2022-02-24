using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Yaxel.Classes
{
    internal class Periphery
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Model { get; set; }
        public int PeripheryTypeId { get; set; }
        public virtual PeripheryType PeripheryType { get; set; }
        public int ManufacturerId { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
        public int StatusId { get; set; }
        public virtual Status Status { get; set; }

        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
