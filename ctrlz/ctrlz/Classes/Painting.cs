using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ctrlz.Classes
{
    public class Painting
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public double Value { get; set; }
        public DateTime DateOfCreation { get; set; }
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }
        public Status Status { get; set; }
    }
}