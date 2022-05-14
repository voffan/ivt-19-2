using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Yaxel.Classes
{
    internal class Component
    {
        public Component()
        {
            Computers = new List<Computer>();
        }
        public int Id { get; set; }
        [MaxLength(50)]
        public string Model { get; set; }
        public ComponentType ComponentType { get; set; }

        public int ManufacturerId { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
        public virtual List<Computer> Computers { get; set; }
        public virtual List<Attribute> Attributes { get; set; }
        [NotMapped]
        public string ComponentTypeTranslation { get { return EnumDictionaries.ComponentTypeTranslation[Enum.GetName(typeof(ComponentType), this.ComponentType)]; } }
    }
}