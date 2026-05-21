using System.ComponentModel.DataAnnotations;

namespace ItransitionProjectMVC.Models;

public class Category
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public ICollection<Inventory> Inventories { get; set; } = [];
}
