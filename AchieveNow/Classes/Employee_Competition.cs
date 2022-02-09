using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AchieveNow.Classes
{
    public class Employee_Competition
    {
        public int EmployeeId { get; set; }
        public virtual Employee? Employee { get; set; }
        public int CompetitionId { get; set; }
        public virtual Competition? Competition { get; set; }
    }
}
