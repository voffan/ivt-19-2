using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AchieveNow.Classes
{
    public class Competition
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Location Location { get; set; }
        public Level Level { get; set; }
        public DateTime DateOfExecution { get; set; }
    }
}
