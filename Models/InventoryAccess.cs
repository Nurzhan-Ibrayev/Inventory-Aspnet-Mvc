using System.ComponentModel.DataAnnotations.Schema;

namespace ItransitionProjectMVC.Models;

public class InventoryAccess
{
    public int InventoryId { get; set; }
    public string UserId { get; set; }
    public DateTime GrantedAt { get; set; } = DateTime.UtcNow;
    
    [ForeignKey(nameof(InventoryId))]
    public Inventory Inventory { get; set; } = null!;
 
    [ForeignKey(nameof(UserId))]
    public AppUser User { get; set; } = null!;
}