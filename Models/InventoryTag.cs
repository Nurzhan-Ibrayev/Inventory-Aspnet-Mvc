using System.ComponentModel.DataAnnotations.Schema;

namespace ItransitionProjectMVC.Models;

public class InventoryTag
{
    public int InventoryId { get; set; }
    public int TagId { get; set; }
 
    [ForeignKey(nameof(InventoryId))]
    public Inventory Inventory { get; set; } = null!;
 
    [ForeignKey(nameof(TagId))]
    public Tag Tag { get; set; } = null!;
}