using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Yaxel.Classes
{
    internal class Periphery
    {
        public Periphery()
        {
            Computers = new List<Computer>();
        }

        public int Id { get; set; }
        [MaxLength(50)]
        public string Model { get; set; }
        public PeripheryType PeripheryType { get; set; }
        public Status Status { get; set; }

        //public int EmployeeId { get; set; }
        //public virtual Employee Employee { get; set; }
        public int ManufacturerId { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
        public virtual List<Computer> Computers { get; set; }
        [NotMapped]
        public string PeripheryStatus { get { return EnumDictionaries.PeripheryStatus[Enum.GetName(typeof(Status), this.Status)]; } }
        [NotMapped]
        public string TranslationType { get { return EnumDictionaries.TranslationType[Enum.GetName(typeof(PeripheryType), this.PeripheryType)]; } }
    }
}
