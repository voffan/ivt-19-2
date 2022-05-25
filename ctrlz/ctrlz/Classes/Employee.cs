using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ctrlz.Classes
{
    public class Employee
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string OwnerID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Bio { get; set; }
        public string Email { get; set; }
        public DateTime HireDate { get; set; }
        public Position Position { get; set; }
    }

    public enum Position
    {
        Handyman,
        Director,
        Administrator
    }

}