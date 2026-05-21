using System.ComponentModel.DataAnnotations;

namespace ItransitionProjectMVC.Models;

public class Tag
{
    public int Id { get; set; }
 
    [Required, MaxLength(100)]
    public string Name { get; set; } = string.Empty;
 
    // Navigation
    public ICollection<InventoryTag> InventoryTags { get; set; } = [];
}