using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Yaxel.Classes
{
    internal class Component
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Model { get; set; }
        public int ComponentTypeId { get; set; }
        public virtual ComponentType ComponentType { get; set; }

        public int ComputerId { get; set; }
        public virtual Computer Computer { get; set; }

        public virtual List<Attribute> Attributes { get; set; }
    }
}
