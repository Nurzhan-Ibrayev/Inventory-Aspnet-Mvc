using System.ComponentModel.DataAnnotations;
using ItransitionProjectMVC.ViewModels.Inventory;

namespace ItransitionProjectMVC.ViewModels.Item;
public class ItemViewModel
{
    public int Id { get; set; }
    public string CustomId { get; set; } = string.Empty;
    public string CreatedByUsername { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }

    public string? CustomString1Value { get; set; }
    public string? CustomString2Value { get; set; }
    public string? CustomString3Value { get; set; }
    public string? CustomMultiline1Value { get; set; }
    public string? CustomMultiline2Value { get; set; }
    public string? CustomMultiline3Value { get; set; }
    public double? CustomInt1Value { get; set; }
    public double? CustomInt2Value { get; set; }
    public double? CustomInt3Value { get; set; }
    public bool? CustomBool1Value { get; set; }
    public bool? CustomBool2Value { get; set; }
    public bool? CustomBool3Value { get; set; }
    public string? CustomLink1Value { get; set; }
    public string? CustomLink2Value { get; set; }
    public string? CustomLink3Value { get; set; }
}
