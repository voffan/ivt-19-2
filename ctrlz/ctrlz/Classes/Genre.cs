using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ctrlz.Classes
{
    public class Genre
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public virtual List<Painting> Paintings { get; set; }
    }
}
