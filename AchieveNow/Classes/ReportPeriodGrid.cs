using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AchieveNow.Classes
{
    public class ReportPeriodGrid
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Result { get; set; }
        public string SportKind { get; set; }
        public DateOnly DateOfExecution { get; set; }
        public string Competition { get; set; }
        public DateOnly DateOfIssue { get; set; }
        public string Gender { get; set; }
        public string Country { get; set; }
    }
}
