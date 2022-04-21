﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Yaxel.Classes
{
    internal class Component
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Model { get; set; }
        public ComponentType ComponentType { get; set; }

        public virtual List<Computer> Computers { get; set; }
        public virtual List<Attribute> Attributes { get; set; }
    }
}
