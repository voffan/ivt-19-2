using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ctrlz.Classes
{
    public class Author
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [DisplayName("Date of Creation")]
        public DateTime DateOfDeath { get; set; }
        public DateTime Birthday { get; set; }
        [DisplayName("Shorth Bio")]
        public string ShortBio { get; set; }

        public virtual List<Painting> Paintings { get; set; }
    }
}
