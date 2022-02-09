using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AchieveNow.Classes
{
    public class Achievement_Sportsman
    {
        public int AchievementId { get; set; }
        public virtual Achievement? Achievement { get; set; }
        public int SportsmanId { get; set; }
        public virtual Sportsman? Sportsman { get; set; }
    }
}
