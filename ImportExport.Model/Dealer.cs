using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportExport.Model
{
    public class Dealer
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey(nameof(Location))]
        public int LocationID { get; set; }
        public Location? Location { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<Car>? Cars { get; set; }
    }
}
