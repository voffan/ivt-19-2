﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ctrlz.Classes
{
    public class Journal
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public int PaintingId { get; set; }
        public virtual Painting Painting { get; set; }
        public DateTime Date { get; set; }
        public int FromId { get; set; }
        [ForeignKey("FromId")]
        public virtual Location From { get; set; }
        public int ToId { get; set; }
        [ForeignKey("ToId")]
        public virtual Location To { get; set; }
    }
}
