using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportExport.Model
{
    public class Location
    {
        [Key]
        public int ID { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }

        public string FullAddress => $"{Address}, {City}, {Country}";
    }
}