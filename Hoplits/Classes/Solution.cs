using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Hoplits.Classes
{
    public class Solution
    {
        public int id { get; set; }
        [MaxLength(500)]
        //[Required(ErrorMessage = "Введите описание решения")]
        public string Description { get; set; }
        [MaxLength(500)]
        //[Required(ErrorMessage = "Введите решение проблемы")]
        public string SolutionOfError { get; set; }

        public int ErrorId { get; set; }
        public virtual Error Error { get; set; }
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
