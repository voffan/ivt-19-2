using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ctrlz.Classes
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }

        public virtual List<Status> Statuses { get; set; }
    }
}
