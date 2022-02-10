using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AchieveNow.Classes
{
    public class Achievement
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public DateTime DateOfIssue { get; set; }
        public byte Results { get; set; }
        public int CompetitionId { get; set; }
        public virtual Competition Competition { get; set; }
        public virtual List<Sportsman> Sportsmen { get; set; } = new();
    }
}
