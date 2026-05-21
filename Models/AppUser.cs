using Microsoft.AspNetCore.Identity;
namespace ItransitionProjectMVC.Models;

public class AppUser:IdentityUser
{
    public ICollection<Inventory> OwnedInventories { get; set; } = [];
    public ICollection<InventoryAccess> InventoryAccesses { get; set; } = [];
    public ICollection<Item> CreatedItems { get; set; } = [];
    public ICollection<Comment> Comments { get; set; } = [];
    public ICollection<Like> Likes { get; set; } = [];
}