using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class TransactionRepository
{
    private readonly NinjaContext _context;

    public TransactionRepository(NinjaContext context)
    {
        _context = context;
    }

    public async Task<Transaction?> Get(int nId, int id)
    {
        return await _context.Transactions.Where(transaction => transaction.NinjaId == nId && transaction.GearId == id).OrderByDescending(t => t.CreatedAt)
            .FirstOrDefaultAsync();
    }

    public async Task<bool> Create(Transaction? transaction)
    {
        await _context.Transactions.AddAsync(transaction);
        return await _context.SaveChangesAsync() > 0;
    }
}