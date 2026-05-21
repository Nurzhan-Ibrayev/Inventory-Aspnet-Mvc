using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItransitionProjectMVC.Models;

public class Comment
{
    public int Id { get; set; }
    public int InventoryId { get; set; }
    public string UserId { get; set; }
 
    [Required]
    public string Content { get; set; } = string.Empty;
 
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
 
    [ForeignKey(nameof(InventoryId))]
    public Inventory Inventory { get; set; } = null!;
 
    [ForeignKey(nameof(UserId))]
    public AppUser User { get; set; } = null!;
}