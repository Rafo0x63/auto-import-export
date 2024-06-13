using ImportExport.DAL;
using ImportExport.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ImportExport.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly ImpExDbContext _context;
        
        public OrderController(ImpExDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var orders = await _context.Orders.Include(c => c.Car).Include(d => d.Dealer).ToListAsync();
            return View(orders);
        }

        public IActionResult Create()
        {
            
            return View();
        }

        public async Task<IActionResult> Create(int carId)
        {
            // Find the car by carId
            var car = await _context.Cars.FindAsync(carId);
            if (car == null)
            {
                return NotFound(); // Handle not found error
            }

            // Create a new Order
            var order = new Order
            {
                Car = car,
                OrderDate = DateTime.Now, // Set order date to current date and time
                DealerID = car.DealerID.Value,
                Price = car.Price
            };

            // Add the order to the context and save changes
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            // Redirect to a success page or another action
            return RedirectToAction(nameof(Index)); // Assuming you have an Index action in your OrderController
        }
    }
}
