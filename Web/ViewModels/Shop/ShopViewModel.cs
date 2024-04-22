using Data.Enums;
using Web.ViewModels.Gear;
using Web.ViewModels.Ninja;

namespace Web.ViewModels.Shop;

public class ShopViewModel
{
    public GearCategory? Category { get; set; }

    public List<GearCategory> Categories { get; set; }
    public Dictionary<GearCategory, IEnumerable<GearViewModel>> GroupedPerCategoryGears { get; set; }

    public NinjaViewModel Ninja { get; set; }
}