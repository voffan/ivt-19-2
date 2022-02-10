using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Hoplits.Classes
{
    public class Employee
    {
        public int id { get; set; }
        [MaxLength(20)]
        //[Required(ErrorMessage = "Введите логин")]
        public string Login { get; set; }
        [MaxLength(256)]
        //[Required(ErrorMessage = "Введите пароль")]
        public string Password { get; set; }
        [MaxLength(50)]
        //[Required(ErrorMessage = "Введите ФИО")]
        public string FullName { get; set; }
        [MaxLength(30)]
        //[Required(ErrorMessage = "Введите номер телефона")]
        public int PhoneNumber { get; set; }
        [MaxLength(20)]
        //[Required(ErrorMessage = "Введите должность")]
        public string Post { get; set; }

        public int EmployerId { get; set; }
        public virtual Employer Employer { get; set; }
    }
}
