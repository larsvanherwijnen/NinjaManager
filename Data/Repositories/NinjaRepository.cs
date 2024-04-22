using Data.Interfaces;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class NinjaRepository : IRepository<Ninja>
{
    private readonly NinjaContext _context;

    public NinjaRepository(NinjaContext context)
    {
        _context = context;
    }

    public async Task<List<Ninja>> GetAll()
    {
        return await _context.Ninjas
            .Include(n => n.NinjaGear)
            .ThenInclude(n => n.Gear)
            .ToListAsync();
    }

    public async Task<Ninja> Get(int id)
    {
        var ninja = await _context.Ninjas
            .Include(n => n.NinjaGear)
            .ThenInclude(n => n.Gear)
            .ThenInclude(n => n.Transactions.OrderByDescending(t => t.CreatedAt))
            .FirstOrDefaultAsync(n => n.Id == id);

        return ninja;
    }

    public async Task<bool> Create(Ninja entity)
    {
        try
        {
            await _context.AddAsync(entity);
            return await _context.SaveChangesAsync() > 0;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<bool> Update(Ninja entity)
    {
        try
        {
            _context.Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<bool> Delete(Ninja entity)
    {
        try
        {
            _context.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}