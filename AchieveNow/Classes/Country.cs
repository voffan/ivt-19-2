using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AchieveNow.Classes
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Sportsman> Sportsmen { get; set; } = new();

        public Country(string Name)
        {
            this.Name = Name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
