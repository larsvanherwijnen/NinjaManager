using Data.Enums;
using Data.Interfaces;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class GearRepository : IRepository<Gear>
{
    private readonly NinjaContext _context;

    public GearRepository(NinjaContext context)
    {
        _context = context;
    }

    public async Task<List<Gear>> GetAll()
    {
        return await _context.Gear
            .Include(gear => gear.NinjaGear)
            .ToListAsync();
    }

    public async Task<Gear> Get(int id)
    {
        return await _context.Gear
            .Include(gear => gear.NinjaGear)
            .ThenInclude(ninjaGear => ninjaGear.Ninja)
            .ThenInclude(gear => gear.Transactions.OrderByDescending(t => t.CreatedAt))
            .FirstOrDefaultAsync(gear => gear.Id == id);
    }
    
    public async Task<bool> Create(Gear gear)
    {
        try
        {
            _context.Add(gear);
            return await _context.SaveChangesAsync() > 0;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<bool> Update(Gear gear)
    {
        try
        {
            _context.Update(gear);
            return await _context.SaveChangesAsync() > 0;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<bool> Delete(Gear gear)
    {
        try
        {
            _context.Remove(gear);
            return await _context.SaveChangesAsync() > 0;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<List<Gear>> GetAllFilteredByCategory(GearCategory? gearCategory)
    {
        var gear = await _context.Gear
            .Where(gear => !gearCategory.HasValue || gear.Category == gearCategory).ToListAsync();

        return gear;
    }
}