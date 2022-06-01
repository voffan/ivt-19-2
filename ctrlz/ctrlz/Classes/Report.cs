using System;
using System.ComponentModel.DataAnnotations;

namespace ctrlz.classes
{
    public class Report
    {
        [DataType(DataType.Date)]
        public DateTime? AcquirementDate { get; set; }

        public int PaintingCount { get; set; }
    }
}