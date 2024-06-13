using System;
using System.ComponentModel.DataAnnotations;

namespace ImportExport.Web.Models
{
    public class CarViewModel
    {
        public int ID { get; set; }

        [Display(Name = "Make")]
        public string Make { get; set; }

        [Display(Name = "Model")]
        public string Model { get; set; }

        [Display(Name = "Year")]
        public DateOnly Year { get; set; }

        [Display(Name = "Mileage")]
        public int Mileage { get; set; }
    }
}
