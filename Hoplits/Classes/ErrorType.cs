using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Hoplits.Classes
{
    public class ErrorType
    {
        public int id { get; set; }
        [MaxLength(100)]
        public int RunTime { get; set; }
        [MaxLength(100)]
        public int Logical { get; set; }
        [MaxLength(100)]
        public int ErrorInCompilation { get; set; }
        [MaxLength(100)]
        public int Ariphmetical { get; set; }

    }
}
