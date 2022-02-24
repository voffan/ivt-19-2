using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Yaxel.Classes
{
    internal class Computer
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public int StatusId { get; set; }
        public virtual Status Status { get; set; }
    }
}
