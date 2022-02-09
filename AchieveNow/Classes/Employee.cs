﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AchieveNow.Classes
{
    public class Employee
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string? Name { get; set; }
        public int PositionId { get; set; }
        public virtual Position? Position { get; set; }
        public virtual List<Employee_Competition> Employee_Competitions { get; set; } = new();
    }
}
