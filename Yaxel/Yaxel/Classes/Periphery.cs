using System.ComponentModel.DataAnnotations;

namespace Yaxel.Classes
{
    internal class Periphery
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Model { get; set; }
        public PeripheryType PeripheryType { get; set; }
        public Status Status { get; set; }

        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public int ManufacturerId { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
    }
}
