using Data.Migrations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data.Models;
using Data.Repositories;
using Web.ViewModels.Gear;
using Web.ViewModels.Ninja;

namespace Web.Controllers
{
    public class NinjaController : Controller
    {
        private readonly NinjaRepository _ninjaRepository;

        public NinjaController(NinjaRepository ninjaRepository)
        {
            _ninjaRepository = ninjaRepository;
        }

        // GET: Ninja
        public async Task<IActionResult> Index(string? errorMessage,
            string? successMessage)
        {
            var ninjas = await _ninjaRepository.GetAll();

            var ninjaViewModels = ninjas.Select(ninja => new NinjaViewModel
            {
                Id = ninja.Id,
                Name = ninja.Name,
                Gold = ninja.Gold,
                Gear = ninja.NinjaGear.Select(gear => new GearViewModel
                {
                    Id = gear.Gear.Id,
                    Name = gear.Gear.Name,
                    Price = gear.Gear.Price,
                    Strength = gear.Gear.Strength,
                    Intelligence = gear.Gear.Intelligence,
                    Agility = gear.Gear.Agility,
                    Category = gear.Gear.Category
                })
            });

            ViewData["ErrorMessage"] = errorMessage;
            ViewData["SuccessMessage"] = successMessage;
            
            return View(ninjaViewModels);
        }

        // GET: Ninja/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Index", new {ErrorMessage = "No ninja found"});
            }

            var ninja = await _ninjaRepository.Get(id.Value);

            if (ninja == null)
            {
                return RedirectToAction("Index", new { ErrorMessage = "No ninja found" });
            }
            
            var ninjaViewModel = new NinjaViewModel
            {
                Id = ninja.Id,
                Name = ninja.Name,
                Gold = ninja.Gold,
                Gear = ninja.NinjaGear.Select(gear => new GearViewModel
                {
                    Id = gear.Gear.Id,
                    Name = gear.Gear.Name,
                    Price = gear.Gear.Price,
                    BoughtFor = gear.Gear.Transactions.FirstOrDefault(transaction => transaction.GearId == gear.GearId)
                        ?.Value,
                    Strength = gear.Gear.Strength,
                    Intelligence = gear.Gear.Intelligence,
                    Agility = gear.Gear.Agility,
                    Category = gear.Gear.Category
                })
            };

            return View(ninjaViewModel);
        }

        // GET: Ninja/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ninja/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NinjaViewModel createNinjaViewModel)
        {
            if (!ModelState.IsValid) return View(createNinjaViewModel);
            var ninja = new Ninja
            {
                Name = createNinjaViewModel.Name,
                Gold = createNinjaViewModel.Gold,
            };

            await _ninjaRepository.Create(ninja);

            return RedirectToAction("Index");
        }

        // GET: Ninja/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", new { ErrorMessage = "No ninja found" });
            }

            var ninja = await _ninjaRepository.Get(id.Value);

            if (ninja == null)
            {
                return RedirectToAction("Index", new { ErrorMessage = "No ninja found" });
            }

            var ninjaViewModel = new NinjaViewModel
            {
                Id = ninja.Id,
                Name = ninja.Name,
                Gold = ninja.Gold,
            };

            return View(ninjaViewModel);
        }

        // POST: Ninja/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(NinjaViewModel editNinjaViewModel)
        {
            if (ModelState.IsValid)
            {
                var ninja = new Ninja
                {
                    Id = editNinjaViewModel.Id,
                    Name = editNinjaViewModel.Name,
                    Gold = editNinjaViewModel.Gold,
                };

                await _ninjaRepository.Update(ninja);

                return RedirectToAction("Index");
            }

            return View(editNinjaViewModel);
        }

        // GET: Ninja/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", new { ErrorMessage = "No ninja found" });
            }

            var ninja = await _ninjaRepository.Get(id.Value);

            if (ninja == null)
            {
                return RedirectToAction("Index", new { ErrorMessage = "No ninja found" });
            }

            var ninjaViewModel = new NinjaViewModel
            {
                Id = ninja.Id,
                Name = ninja.Name,
                Gold = ninja.Gold,
            };

            return View(ninjaViewModel);
        }

        // POST: Ninja/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var ninja = await _ninjaRepository.Get(id);


            ninja.NinjaGear.Clear();

            await _ninjaRepository.Delete(ninja);
            return RedirectToAction("Index");
        }

        // POST: Ninja/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Clear(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", new { ErrorMessage = "No ninja found" });
            }

            var ninja = await _ninjaRepository.Get(id.Value);

            if (ninja == null)
            {
                return RedirectToAction("Index", new { ErrorMessage = "No ninja found" });
            }
            
            if (!ninja.NinjaGear.Any())
            {
                return RedirectToAction("Index", new { ErrorMessage = "Inventory does not contain any items" });
            }

            var currentItems = ninja.NinjaGear.Select(gear => gear.GearId).ToList();

            var latestTransactions = ninja.Transactions
                .Where(t => currentItems.Contains(t.GearId))
                .OrderByDescending(t => t.CreatedAt)
                .GroupBy(t => t.GearId)
                .Select(group => group.First())
                .ToList();

            var totalValue = latestTransactions.Sum(t => t.Value);

            ninja.Gold += totalValue;

            ninja.NinjaGear.Clear();

            await _ninjaRepository.Update(ninja);

            return RedirectToAction("Index");
        }
    }
}