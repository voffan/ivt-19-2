using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ctrlz.Classes
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfDeath { get; set; }
        public DateTime Birthday { get; set; }
        public string ShortBio { get; set; }

        public virtual List<Painting> Paintings { get; set; }
    }
}
