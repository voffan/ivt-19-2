using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AchieveNow.Classes
{
    public class Position
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string? Judge { get; set; }
        [MaxLength(50)]
        public string? User { get; set; }
    }
}
