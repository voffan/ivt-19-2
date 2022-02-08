using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AchieveNow.Classes
{
    public class Achievement
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfIssue { get; set; }
        public byte Results { get; set; }
    }
}
