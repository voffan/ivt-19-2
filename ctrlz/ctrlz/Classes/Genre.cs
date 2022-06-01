using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
