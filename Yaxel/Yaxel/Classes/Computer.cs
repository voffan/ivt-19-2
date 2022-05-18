using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Yaxel.Classes
{
    internal class Computer
    {
        public Computer()
        {
            Components = new List<Component>();
            Peripheries = new List<Periphery>();
        }

        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public Status Status { get; set; }

        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual List<Component> Components { get; set; }
        public virtual List<Periphery> Peripheries { get; set; }
        [NotMapped]
        public string CompStatus { get { return EnumDictionaries.CompStatus[Enum.GetName(typeof(Status), this.Status)]; } }
    }
}
