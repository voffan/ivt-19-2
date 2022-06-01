using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ctrlz.Classes
{
    public class Location
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public string Adress { get; set; }
        [DisplayName("Location Type")]
        public LocationType LocationType { get; set; }

        public virtual List<Painting> Paintings { get; set; }
    }
    public enum LocationType
    {
        Storage,
        Expo,
        Recovery
    }
}
