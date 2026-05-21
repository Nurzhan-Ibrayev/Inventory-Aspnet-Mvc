using System.ComponentModel.DataAnnotations.Schema;

namespace ItransitionProjectMVC.Models;

public class Like
{
    public int ItemId { get; set; }
    public string UserId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
 
    [ForeignKey(nameof(ItemId))]
    public Item Item { get; set; } = null!;
 
    [ForeignKey(nameof(UserId))]
    public AppUser User { get; set; } = null!;
}