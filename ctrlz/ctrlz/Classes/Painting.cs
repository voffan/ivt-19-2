using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ctrlz.Classes
{
    public class Painting
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public double Value { get; set; }
        [DisplayName("Date of Creation")]
        public DateTime DateOfCreation { get; set; }
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }
        public Status Status { get; set; }
        [DisplayName("Acquirement Date")]
        public DateTime AcquirementDate { get; set; }
    }
    public enum Status
    {
        [Display(Name = "In Expo")]
        InExpo,
        [Display(Name = "In Storage")]
        InStorage,
        [Display(Name = "In Recovery")]
        InRecovery
    }
}