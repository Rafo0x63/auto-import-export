using ImportExport.DAL;
using ImportExport.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

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
            var orders = await _context.Orders.ToListAsync();
            return View(orders);
        }

        public async Task<IActionResult> Create(int carId)
        {
            var car = _context.Cars.Include(d => d.Dealer).Where(c => c.ID == carId).FirstOrDefault();
            if (car == null)
            {
                return NotFound();
            }

            var order = new Order
            {
                CarInfo = $"{car.CarName} ({car.Year})",
                OrderDate = DateTime.Now,
                DealerName = car.Dealer.Name,
                Price = car.Price
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index)); 
        }
    }
}
