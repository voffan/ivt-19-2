using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AchieveNow.Classes
{
    public class Level
    {
        /*public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public virtual List<Competition> Competitions { get; set; } = new();*/

        enum level
        {
            Municipal,
            District,
            Regional,
            Interregional,
            Nationwide,
            International,
            Worldwide
        }
    }
}
