using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AchieveNow.Classes
{
    public class User
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Login { get; set; }
        [MaxLength(50)]
        public string Password { get; set; }
        public Position Position { get; set; }
    }
}
