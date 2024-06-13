using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImportExport.Model
{
    public class Car
    {
        [Key]
        public int ID { get; set; }
        public string Year { get; set; }
        public int Power { get; set; }
        public int Mileage { get; set; }
        public float FuelConsumption { get; set; }
        public int Price { get; set; }
        public int PreviousOwners { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Fuel { get; set; }
        public string Transmission { get; set; }

        [ForeignKey(nameof(Dealer))]
        public int? DealerID { get; set; }
        public Dealer? Dealer { get; set; }

        public string CarName => $"{Make} {Model}";
    }
}