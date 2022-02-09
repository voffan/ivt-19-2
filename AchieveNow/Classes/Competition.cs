﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AchieveNow.Classes
{
    public class Competition
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string? Name { get; set; }
        
        public int LevelId { get; set; }
        public virtual Level? Level { get; set; }
        public int LocationId { get; set; }
        public virtual Location? Location { get; set; }
        public int SportKindId { get; set; }
        public virtual SportKind? SportKind { get; set; }
        public DateTime DateOfExecution { get; set; }
        public virtual List<Achievement> Achievements { get; set; } = new();
        public virtual List<Employee_Competition> Employee_Competitions { get; set; } = new();
    }
}
