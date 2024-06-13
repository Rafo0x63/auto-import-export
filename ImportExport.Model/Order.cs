using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportExport.Model
{
    public class Order
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey(nameof(Car))]
        public int CarID { get; set; }
        public Car Car { get; set; }
        [ForeignKey(nameof(Dealer))]
        public int DealerID { get; set; }
        public Dealer Dealer { get; set; }
        public DateTime OrderDate { get; set; }
        public int Price { get; set; }
    }
}
