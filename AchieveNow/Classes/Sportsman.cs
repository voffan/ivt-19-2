using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AchieveNow.Classes
{
    public class Sportsman
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public string? Gender { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
