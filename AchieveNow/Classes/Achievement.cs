using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AchieveNow.Classes
{
    public class Achievement
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public DateOnly DateOfIssue { get; set; }
        public Result Result { get; set; }
        public int CompetitionId { get; set; }
        public virtual Competition Competition { get; set; }
        public int SportsmanId { get; set; }
        public virtual Sportsman Sportsmen { get; set; }

        public Achievement(string name, DateOnly dateOfIssue, Result result, int competitionId)
        {
            Name = name;
            DateOfIssue = dateOfIssue;
            Result = result;
            CompetitionId = competitionId;
        }
    }
}
