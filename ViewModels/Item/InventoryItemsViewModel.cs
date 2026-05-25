namespace ItransitionProjectMVC.ViewModels.Item;


public class InventoryItemsViewModel
{
    public int InventoryId { get; set; }
    public string InventoryTitle { get; set; } = string.Empty;

    public string? CustomString1Name { get; set; }
    public string? CustomString1State { get; set; }
    public string? CustomString2Name { get; set; }
    public string? CustomString2State { get; set; }
    public string? CustomString3Name { get; set; }
    public string? CustomString3State { get; set; }
    public string? CustomMultiline1Name { get; set; }
    public string? CustomMultiline1State { get; set; }
    public string? CustomMultiline2Name { get; set; }
    public string? CustomMultiline2State { get; set; }
    public string? CustomMultiline3Name { get; set; }
    public string? CustomMultiline3State { get; set; }
    public string? CustomInt1Name { get; set; }
    public string? CustomInt1State { get; set; }
    public string? CustomInt2Name { get; set; }
    public string? CustomInt2State { get; set; }
    public string? CustomInt3Name { get; set; }
    public string? CustomInt3State { get; set; }
    public string? CustomBool1Name { get; set; }
    public string? CustomBool1State { get; set; }
    public string? CustomBool2Name { get; set; }
    public string? CustomBool2State { get; set; }
    public string? CustomBool3Name { get; set; }
    public string? CustomBool3State { get; set; }
    public string? CustomLink1Name { get; set; }
    public string? CustomLink1State { get; set; }
    public string? CustomLink2Name { get; set; }
    public string? CustomLink2State { get; set; }
    public string? CustomLink3Name { get; set; }
    public string? CustomLink3State { get; set; }

    public bool CanEdit { get; set; } 
    public List<ItemViewModel> Items { get; set; } = [];
}