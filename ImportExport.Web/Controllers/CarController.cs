using ImportExport.DAL;
using ImportExport.Model;
using ImportExport.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class CarController : Controller
{
    private readonly ImpExDbContext _context;

    public CarController(ImpExDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var cars = await _context.Cars.Include(c => c.Dealer).ToListAsync();
        return View(cars);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var car = await _context.Cars
            .Include(c => c.Dealer)
            .FirstOrDefaultAsync(m => m.ID == id);

        if (car == null)
        {
            return NotFound();
        }

        return View(car);
    }

    public IActionResult Create()
    {
        ViewData["DealerID"] = new SelectList(
            _context.Dealers.Select(d => new { d.ID, d.Name }).ToList(),
            "ID", "Name"
        ).Prepend(new SelectListItem { Value = "", Text = "-- choose one or leave empty --" });

        ViewData["Fuel"] = new SelectList(new List<string> { "-- choose one --", "Gasoline", "Diesel", "Hybrid" }, "-- choose one --");
        ViewData["Transmission"] = new SelectList(new List<string> { "-- choose one --", "Manual", "Automatic" }, "-- choose one --");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("ID,Year,Power,Mileage,FuelConsumption,Price,PreviousOwners,Make,Model,Fuel,Transmission,DealerID")] Car car)
    {
        if (ModelState.IsValid)
        {
            _context.Add(car);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        ViewData["DealerID"] = new SelectList(
            _context.Dealers.Select(d => new { d.ID, d.Name }).ToList(),
            "ID", "Name", car.DealerID
        ).Prepend(new SelectListItem { Value = "", Text = "-- choose one or leave empty --" });

        ViewData["Fuel"] = new SelectList(new List<string> { "-- choose one --", "Gasoline", "Diesel", "Hybrid" }, car.Fuel);
        ViewData["Transmission"] = new SelectList(new List<string> { "-- choose one --", "Manual", "Automatic" }, car.Transmission);
        return View(car);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var car = await _context.Cars.FindAsync(id);
        if (car == null)
        {
            return NotFound();
        }

        ViewData["DealerID"] = new SelectList(
            _context.Dealers.Select(d => new { d.ID, d.Name }).ToList(),
            "ID", "Name"
        ).Prepend(new SelectListItem { Value = "", Text = "-- choose one or leave empty --" });

        ViewData["Fuel"] = new SelectList(new List<string> { "-- choose one --", "Gasoline", "Diesel", "Hybrid" }, "-- choose one --");
        ViewData["Transmission"] = new SelectList(new List<string> { "-- choose one --", "Manual", "Automatic" }, "-- choose one --");
        return View(car);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("ID,Make,Model,Year,Power,Mileage,FuelConsumption,Price,PreviousOwners,Fuel,Transmission,DealerID")] Car car)
    {
        if (id != car.ID)
        {
            return NotFound();
        }


        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(car);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(car.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(car);
    }

    private bool CarExists(int id)
    {
        return _context.Cars.Any(e => e.ID == id);
    }


}
