using System.ComponentModel.DataAnnotations;
using Data.Enums;

namespace Data.Models;

public class Gear
{
    [Key] public int Id { get; set; }

    [Required] 
    public string Name { get; set; }

    [Required] 
    public int Price { get; set; }

    public int Strength { get; set; }
    public int Agility { get; set; }
    public int Intelligence { get; set; }
    public GearCategory Category { get; set; }

    public virtual ICollection<Transaction> Transactions { get; set; }
    public virtual ICollection<NinjaGear> NinjaGear { get; set; }
}