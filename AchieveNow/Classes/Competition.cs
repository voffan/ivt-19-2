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
        public string? Name { get; set; }
        public int LocationId { get; set; }
        public Location? Location { get; set; }
        public int LevelId { get; set; }
        public Level? Level { get; set; }
        public DateTime DateOfExecution { get; set; }
    }
}
