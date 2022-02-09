using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ctrlz.Classes
{
    public class Status
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int LocationId { get; set; }
        public virtual Location Location { get; set; }

        public virtual List<Painting> Paintings { get; set; }
    }
}