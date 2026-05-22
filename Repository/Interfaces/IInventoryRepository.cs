using ItransitionProjectMVC.Models;

namespace ItransitionProjectMVC.Repository.Interfaces;

public interface IInventoryRepository
{
    Task<List<Inventory>> GetAllAsync();
    Task<Inventory?> GetByIdAsync(int id);
    Task<Inventory> AddAsync(Inventory inventoryModel);
    Task UpdateAsync();
    Task DeleteAsync(Inventory inventoryModel);
}