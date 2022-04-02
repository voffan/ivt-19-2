using System;
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
        public string Name { get; set; }
        public Level Level { get; set; }
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }
        public int SportKindId { get; set; }
        public virtual SportKind SportKind { get; set; }
        public DateOnly DateOfExecution { get; set; }
        public virtual List<Employee> Employees { get; set; } = new();

        public Competition(string name, Level level, int locationId, int sportKindId, DateOnly dateOfExecution)
        {
            Name = name;
            Level = level;
            LocationId = locationId;
            SportKindId = sportKindId;
            DateOfExecution = dateOfExecution;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
