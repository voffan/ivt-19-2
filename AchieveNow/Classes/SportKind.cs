using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AchieveNow.Classes
{
    public class SportKind
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public SportKind(string Name)
        {
            this.Name = Name;
        }
    }
}
