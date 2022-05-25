using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Yaxel.Classes
{
    internal class Employee
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Position Position { get; set; }

        public virtual List<Computer> Computers { get; set; }
        //public virtual List<Periphery> Peripheries { get; set; }
        [NotMapped]
        public string EmployeePosition { get { return EnumDictionaries.EmployeePosition[Enum.GetName(typeof(Position), this.Position)]; } }

    }
}
