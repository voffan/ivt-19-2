using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AchieveNow.Classes
{
    public class SportKind
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public virtual List<Competition> Competitions { get; set; } = new();
        public virtual List<Sportsman> Sportsmen { get; set; } = new();

        public SportKind(string Name)
        {
            this.Name = Name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
