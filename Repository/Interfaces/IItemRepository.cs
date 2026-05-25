using ItransitionProjectMVC.Models;

namespace ItransitionProjectMVC.Repository.Interfaces;

public interface IItemRepository
{
    Task<List<Item>> GetByInventoryIdAsync(int inventoryId);
    Task<Item?> GetByIdAsync(int id);
    Task<Item> AddAsync(Item item);
    Task UpdateAsync();
    Task DeleteAsync(Item item);
}