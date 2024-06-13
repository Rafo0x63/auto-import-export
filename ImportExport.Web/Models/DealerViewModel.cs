using System.ComponentModel.DataAnnotations;

namespace ImportExport.Web.Models
{
    public class DealerViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        [Display(Name = "Number of Cars")]
        public int CarsInDealership { get; set; }
    }
}
