using Microsoft.EntityFrameworkCore;

namespace Data.Models;

[PrimaryKey(nameof(NinjaId), nameof(GearId))]
public class NinjaGear
{
    public int NinjaId { get; set; }
    public int GearId { get; set; }
    public Ninja Ninja { get; set; }
    public Gear Gear { get; set; }
}