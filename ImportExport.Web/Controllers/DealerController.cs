using ImportExport.DAL;
using ImportExport.Model;
using ImportExport.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

public class DealerController : Controller
{
    private readonly ImpExDbContext _context;

    public DealerController(ImpExDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var dealers = await _context.Dealers
            .Include(d => d.Location)
            .Select(d => new DealerViewModel
            {
                ID = d.ID,
                Name = d.Name,
                Email = d.Email,
                Location = d.Location.Country,
                CarsInDealership = d.Cars.Count
            })
            .ToListAsync();

        return View(dealers);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var dealer = await _context.Dealers
            .Include(d => d.Location)
            .Include(d => d.Cars)
            .FirstOrDefaultAsync(m => m.ID == id);

        if (dealer == null)
        {
            return NotFound();
        }

        return View(dealer);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var dealer = await _context.Dealers
            .Include(d => d.Location)
            .Include (d => d.Cars)
            .FirstOrDefaultAsync(m => m.ID == id);


        if (dealer == null)
        {
            return NotFound();
        }
        ViewData["LocationID"] = new SelectList(
            _context.Locations.Select(l => new { l.ID, l.FullAddress}).ToList(),
            "ID", "FullAddress"
        ).Prepend(new SelectListItem { Value = "", Text = "-- choose one --" });

        ViewBag.Cars = _context.Cars.Where(c => c.DealerID == null).ToList();

        return View(dealer);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("ID,LocationID,Name,Email,PhoneNumber")] Dealer dealer)
    {
        if (id != dealer.ID)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(dealer);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DealerExists(dealer.ID))
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
        ViewData["LocationID"] = new SelectList(
            _context.Locations.Select(l => new { l.ID, l.FullAddress }).ToList(),
            "ID", "FullAddress"
        ).Prepend(new SelectListItem { Value = "", Text = "-- choose one --" });

        return View(dealer);
    }

    private bool DealerExists(int id)
    {
        return _context.Dealers.Any(e => e.ID == id);
    }

    [HttpPost]
    public async Task<IActionResult> RemoveCar(int dealerId, int carId)
    {
        var dealer = await _context.Dealers
                                   .Include(d => d.Cars)
                                   .FirstOrDefaultAsync(d => d.ID == dealerId);
        if (dealer == null)
        {
            return NotFound();
        }

        var carToRemove = dealer.Cars.FirstOrDefault(c => c.ID == carId);
        if (carToRemove != null)
        {
            dealer.Cars.Remove(carToRemove);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Edit), new { id = dealerId });
    }


    [HttpPost]
    public async Task<IActionResult> AddCar(int dealerId, int carId)
    {
        var dealer = await _context.Dealers
                                   .Include(d => d.Cars)
                                   .FirstOrDefaultAsync(d => d.ID == dealerId);
        if (dealer == null)
        {
            return NotFound();
        }

        var carToAdd = _context.Cars.FirstOrDefault(c => c.ID == carId);
        if (carToAdd != null)
        {
            dealer.Cars.Add(carToAdd);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Edit), new { id = dealerId });
    }

}
