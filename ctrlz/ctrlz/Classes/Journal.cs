﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ctrlz.Classes
{
    class Journal
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public int PaintingId { get; set; }
        public virtual Painting Painting { get; set; }
        public DateTime Date { get; set; }
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public int LocationId { get; set; }
        public virtual Location from { get; set; }
        public virtual Location to { get; set; }
    }
}
