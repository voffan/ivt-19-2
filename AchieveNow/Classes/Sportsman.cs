using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AchieveNow.Classes
{
    public class Sportsman
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string? Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        [Range(0,300)]
        public int Height { get; set; }
        [Range(0, 470)]
        public int Weight { get; set; }
        [MaxLength(50)]
        public string? Gender { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
