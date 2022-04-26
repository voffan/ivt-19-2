using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AchieveNow.Classes
{
    public class Sportsman
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public DateOnly DateOfBirth { get; set; }
        [Range(0,300)]
        public int Height { get; set; }
        [Range(0, 470)]
        public int Weight { get; set; }
        [MaxLength(50)]
        public Gender Gender { get; set; }
        public int SportKindId { get; set; }
        public virtual SportKind SportKind { get; set; }
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
        public virtual List<Achievement> Achievements { get; set; }

        public Sportsman(string name, DateOnly dateOfBirth, int height, int weight, Gender gender, int sportKindId, int countryId)
        {
            Name = name;
            DateOfBirth = dateOfBirth;
            Height = height;
            Weight = weight;
            Gender = gender;
            SportKindId = sportKindId;
            CountryId = countryId;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
