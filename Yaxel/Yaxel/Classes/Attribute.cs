using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Yaxel.Classes
{
    internal class Attribute
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public AttrType AttrType { get; set; }

        public int ComponentId { get; set; }
        public virtual Component Component { get; set; }
        [NotMapped]
        public string AttrTypeTranslation { get { return EnumDictionaries.AttrTypeTranslation[Enum.GetName(typeof(AttrType), this.AttrType)]; } }
    }
}
