using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace AchieveNow.Classes
{
    [Index("Login", IsUnique = true)]
    public class User
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Login { get; set; }
        [MaxLength(50)]
        public string Password { get; set; }
        public Position Position { get; set; }

        public static Position position = (Position)(-1);
    }
}
