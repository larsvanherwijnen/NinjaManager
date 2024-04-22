using Data.Enums;

namespace Data.Models;

public class Transaction
{
    public int Id { get; set; }
    public int? NinjaId { get; set; }
    public int GearId { get; set; }
    public TransactionType Type { get; set; }
    public int Value { get; set; }
    public DateTime CreatedAt { get; set; }

    public Ninja Ninja { get; set; }
    public Gear Gear { get; set; }
}