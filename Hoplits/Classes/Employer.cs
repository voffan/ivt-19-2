using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Hoplits.Classes
{
    public class Employer
    {
        public int id { get; set; }
        [MaxLength(50)]
        //[Required(ErrorMessage = "Введите название")]
        public string name { get; set; }

        public virtual List<Employee> Employees { get; set; }
    }
}
