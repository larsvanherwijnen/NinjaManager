using System.ComponentModel.DataAnnotations;
using Data.Enums;

namespace Web.ViewModels.Gear;

public class GearViewModel
{
    [Required] public int Id { get; set; }

    [Required] public string Name { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Price must be a positive number")]
    [Required]
    public int Price { get; set; }
    public int? BoughtFor { get; set; }

    [Required]
    [Range(0.0, int.MaxValue, ErrorMessage = "Strength must be a positive number")]
    public int Strength { get; set; }

    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "Agility must be a positive number")]
    public int Agility { get; set; }

    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "Intelligence must be a positive number")]
    public int Intelligence { get; set; }

    [Required]
    public GearCategory Category { get; set; }

    public bool HasEquipmentInCategory { get; set; }

    public bool OwnsGear { get; set; }

    public int Count { get; set; }
}