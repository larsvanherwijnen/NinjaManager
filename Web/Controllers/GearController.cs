using Data.Models;
using Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Web.ViewModels.Gear;

namespace Web.Controllers;

public class GearController : Controller
{
    private readonly GearRepository _gearRepository;

    public GearController(GearRepository gearRepository)
    {
        _gearRepository = gearRepository;
    }

    // GET: GearViewModel
    public async Task<IActionResult> Index(string? errorMessage,
        string? successMessage)
    {
        var gears = await _gearRepository.GetAll();

        var gearViewModel = gears.Select(gear => new GearViewModel()
        {
            Id = gear.Id,
            Name = gear.Name,
            Price = gear.Price,
            Strength = gear.Strength,
            Intelligence = gear.Intelligence,
            Agility = gear.Agility,
            Category = gear.Category,
            Count = gear.NinjaGear.Count(c => c.GearId == gear.Id)
        });

        ViewData["ErrorMessage"] = errorMessage;
        ViewData["SuccessMessage"] = successMessage;
        
        return View(gearViewModel);
    }

    // GET: GearViewModel/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: GearViewModel/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(GearViewModel creatGearViewModel)
    {
        if (ModelState.IsValid)
        {
            var gear = new Gear
            {
                Name = creatGearViewModel.Name,
                Price = creatGearViewModel.Price,
                Strength = creatGearViewModel.Strength,
                Intelligence = creatGearViewModel.Intelligence,
                Agility = creatGearViewModel.Agility,
                Category = creatGearViewModel.Category
            };

            if (await _gearRepository.Create(gear))
            {
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The gear could not be created.");
        }

        return View(creatGearViewModel);
    }

    // GET: GearViewModel/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return RedirectToAction("Index", new {ErrorMessage = "No gear found"});
        }

        var gear = await _gearRepository.Get(id.Value);

        var model = new GearViewModel
        {
            Id = gear.Id,
            Name = gear.Name,
            Price = gear.Price,
            Strength = gear.Strength,
            Intelligence = gear.Intelligence,
            Agility = gear.Agility,
            Category = gear.Category
        };

        
        return View(model);
    }

    // POST: GearViewModel/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(GearViewModel editGearViewModel)
    {
        if (ModelState.IsValid)
        {
            var gear = await _gearRepository.Get(editGearViewModel.Id);

            gear.Name = editGearViewModel.Name;
            gear.Price = editGearViewModel.Price;
            gear.Strength = editGearViewModel.Strength;
            gear.Intelligence = editGearViewModel.Intelligence;
            gear.Agility = editGearViewModel.Agility;
            gear.Category = editGearViewModel.Category;

            if (await _gearRepository.Update(gear))
            {
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The gear could not be edited.");
        }

        return View(editGearViewModel);
    }

    // POST: GearViewModel/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        var gear = await _gearRepository.Get(id);


        if (gear.Transactions != null && gear.Transactions.Any())
        {
            var latestTransactions = gear.Transactions
                .Where(t => t.NinjaId != null)
                .GroupBy(t => t.NinjaId)
                .Select(group => group.First())
                .ToList();
            
            foreach (var ninjaGear in gear.NinjaGear)
            {
                ninjaGear.Ninja.Gold += latestTransactions
                    .Where(t => t.NinjaId == ninjaGear.NinjaId)
                    .Sum(t => t.Value);
            }
            
            gear.Transactions.Clear();
        }
        
        gear.NinjaGear.Clear();
        
        if (await _gearRepository.Delete(gear))
        {
            return RedirectToAction("Index");
        }

        return RedirectToAction("Index", new { id, saveChangesError = true });
    }
}