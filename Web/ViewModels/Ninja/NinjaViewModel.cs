using System.ComponentModel.DataAnnotations;
using Web.ViewModels.Gear;

namespace Web.ViewModels.Ninja;

public class NinjaViewModel
{
    public int Id { get; set; }

    [MaxLength(45)][Required] public string Name { get; set; }

    [Range(0, Int32.MaxValue, ErrorMessage = "Gold must be a positive number")]
    public int Gold { get; set; }

    public IEnumerable<GearViewModel>? Gear { get; set; }

    public int TotalStrength => Gear?.Sum(g => g.Strength) ?? 0;

    public int TotalAgility => Gear?.Sum(g => g.Agility) ?? 0;

    public int TotalIntelligence => Gear?.Sum(g => g.Intelligence) ?? 0;

    public int TotalGearValue => Gear?.Sum(g => g.BoughtFor) ?? 0;
}