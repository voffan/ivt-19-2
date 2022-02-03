using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace AchieveNow.Classes
{
    public class Achievements
    {
        [MaxLength(300)]
        private string Name { get; set; }
        
        [Range(1950, 2100)]
        private DateTime Dateofissue { get; set; }
        
        [Range(0, 3)]
        private byte Results { get; set; }
    }
}
