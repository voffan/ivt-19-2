using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Hoplits.Classes
{
    public class Error
    {
        public int id { get; set; }
        [MaxLength(500)]
        [Required(ErrorMessage = "Введите описание ошибки")]
        public string Description { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Введите дату")]
        public DateTime Date { get; set; }

        public int ErrorTypeId { get; set; }
        public virtual ErrorType ErrorType { get; set; }
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
