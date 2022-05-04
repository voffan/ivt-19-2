using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Yaxel.Classes
{
    internal class Manufacturer
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual List<Component> Components { get; set; }
        public virtual List<Periphery> Peripheries { get; set; }
    }
}
