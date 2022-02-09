using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AchieveNow.Classes
{
    public class Gender {
        public int Id { get; set; }
        [MaxLength(50)]
        public string? Name { get; set; }
        public virtual List<Sportsman> Sportsmans { get; set; } = new();
    }
}
