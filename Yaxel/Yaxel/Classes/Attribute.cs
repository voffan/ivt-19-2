using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Yaxel.Classes
{
    internal class Attribute
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public int AttrTypeId { get; set; }
        public virtual AttrType AttrType { get; set; }
    }
}
