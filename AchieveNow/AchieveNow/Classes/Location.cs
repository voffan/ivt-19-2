using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AchieveNow.Classes
{
    public class Location
    {
        [MaxLength(300)]
        private string Place { get; set; }
        
    }
}
