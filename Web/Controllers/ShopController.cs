using Data.Enums;
using Data.Models;
using Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Web.ViewModels.Gear;
using Web.ViewModels.Ninja;
using Web.ViewModels.Shop;

namespace Web.Controllers;

[Route("/Shop/{nId:int}/{action=Index}/{id?}")]
public class ShopController : Controller
{
    private readonly GearRepository _gearsRepository;
    private readonly NinjaRepository _ninjaRepository;
    private readonly TransactionRepository _transactionRepository;

    public ShopController(NinjaRepository ninjaRepository, GearRepository gearsRepository,
        TransactionRepository transactionRepository)
    {
        _ninjaRepository = ninjaRepository;
        _gearsRepository = gearsRepository;
        _transactionRepository = transactionRepository;
    }

    public async Task<IActionResult> Index(int nId, GearCategory? category, string? errorMessage,
        string? successMessage)
    {
        if (nId == null)
        {
            return RedirectToAction("Index", "Ninja", new { ErrorMessage = "No ninja found" });
        }

        var ninja = await _ninjaRepository.Get(nId);
        
        if (ninja == null)
        {
            return RedirectToAction("Index", "Ninja", new { ErrorMessage = "No ninja found" });
        }

        var gears = await _gearsRepository.GetAllFilteredByCategory(category);
        var groupedGear = gears
            .GroupBy(gear => gear.Category)
            .ToDictionary(
                group => group.Key,
                group => group.Select(gear => new GearViewModel
                {
                    Id = gear.Id,
                    Name = gear.Name,
                    Price = gear.Price,
                    Agility = gear.Agility,
                    Intelligence = gear.Intelligence,
                    Strength = gear.Strength,
                    HasEquipmentInCategory = HasEquipmentInCategory(ninja, gear.Category),
                    OwnsGear = OwnsGear(ninja, gear),
                }));

        var shopViewModel = new ShopViewModel
        {
            Category = category,
            Categories = Enum.GetValues(typeof(GearCategory))
                .Cast<GearCategory>()
                .ToList(),
            Ninja = new NinjaViewModel
            {
                Id = ninja.Id,
                Name = ninja.Name,
                Gold = ninja.Gold
            },
            GroupedPerCategoryGears = groupedGear
        };

        ViewData["ErrorMessage"] = errorMessage;
        ViewData["SuccessMessage"] = successMessage;

        return View(shopViewModel);
    }

    private bool HasEquipmentInCategory(Ninja ninja, GearCategory category)
    {
        return ninja.NinjaGear.Any(ninjaGear => ninjaGear.Gear.Category == category);
    }

    private bool OwnsGear(Ninja ninja, Gear gear)
    {
        return ninja.NinjaGear.Any(ninjaGear => ninjaGear.GearId == gear.Id);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Buy(int nId, int id)
    {
        var ninja = await _ninjaRepository.Get(nId);

        var gear = await _gearsRepository.Get(id);

        if (ninja == null || gear == null)
        {
            return RedirectToAction("Index", new { nId, ErrorMessage = "No ninja or gear found" });
        }

        if (ninja.Gold < gear.Price)
        {
            return RedirectToAction("Index", new { nId, ErrorMessage = "You dont have enough gold to buy this item" });
        }
        
        if (HasEquipmentInCategory(ninja, gear.Category))
        {
            return RedirectToAction("Index", new { nId, ErrorMessage = "You already own an item in this category" });
        }
        
        ninja.Gold -= gear.Price;
        ninja.NinjaGear.Add(new NinjaGear
        {
            GearId = gear.Id
        });

        var transaction = new Transaction
        {
            NinjaId = ninja.Id,
            GearId = gear.Id,
            Type = TransactionType.Buy,
            Value = gear.Price
        };

        if (await _ninjaRepository.Update(ninja) && await _transactionRepository.Create(transaction))
        {
            return RedirectToAction("Index", new { nId, SuccessMessage = $"You bought the {gear.Name}" });
        }

        return RedirectToAction("Index", new { nId, ErrorMessage = "Something went wrong try again later" });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Sell(int nId, int id)
    {
        var ninja = await _ninjaRepository.Get(nId);

        var gear = await _gearsRepository.Get(id);

        if (ninja == null || gear == null)
        {
            return RedirectToAction("Index", new { nId, ErrorMessage = "No ninja or gear found" });
        }

        var buyTransaction = await _transactionRepository.Get(nId, id);

        var ninjaGear = ninja.NinjaGear.FirstOrDefault(ninjaGear => ninjaGear.GearId == id);

        if (ninjaGear == null)
        {
            return RedirectToAction("Index", new { nId, ErrorMessage = "You dont own this gear" });
        }

        ninja.Gold += buyTransaction.Value;
        ninja.NinjaGear.Remove(ninjaGear);


        var transaction = new Transaction
        {
            NinjaId = ninja.Id,
            GearId = gear.Id,
            Type = TransactionType.Sell,
            Value = gear.Price
        };


        if (await _ninjaRepository.Update(ninja) && await _transactionRepository.Create(transaction))
        {
            return RedirectToAction("Index", new {nId, SuccessMessage = $"You sold the {gear.Name} for {buyTransaction.Value}" });
        }

        return RedirectToAction("Index", new { nId, ErrorMessage = "Something went wrong try again later" });
    }
}