using System.ComponentModel.DataAnnotations;
using ItransitionProjectMVC.ViewModels.Inventory;

namespace ItransitionProjectMVC.ViewModels.Item;


public class CreateItemViewModel
{
    public int InventoryId { get; set; }
    public InventoryDetailsViewModel? Inventory { get; set; } = null!;
    [MaxLength(1024)] public string? CustomString1Value { get; set; }
    [MaxLength(1024)] public string? CustomString2Value { get; set; }
    [MaxLength(1024)] public string? CustomString3Value { get; set; }
    public string? CustomMultiline1Value { get; set; }
    public string? CustomMultiline2Value { get; set; }
    public string? CustomMultiline3Value { get; set; }
    public double? CustomInt1Value { get; set; }
    public double? CustomInt2Value { get; set; }
    public double? CustomInt3Value { get; set; }
    public bool? CustomBool1Value { get; set; }
    public bool? CustomBool2Value { get; set; }
    public bool? CustomBool3Value { get; set; }
    [MaxLength(2048)] public string? CustomLink1Value { get; set; }
    [MaxLength(2048)] public string? CustomLink2Value { get; set; }
    [MaxLength(2048)] public string? CustomLink3Value { get; set; }
}