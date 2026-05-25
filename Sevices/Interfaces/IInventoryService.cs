using ItransitionProjectMVC.ViewModels.Inventory;

namespace ItransitionProjectMVC.Sevices.Interfaces;

public interface IInventoryService
{
    Task<List<InventoryViewModel>> GetAllInventoryAsync();
    Task<InventoryViewModel> GetByIdInventoryAsync(int id);
    Task<InventoryDetailsViewModel> GetByIdInventoryDetailsAsync(int id);
    Task CreateInventoryAsync(CreateInventoryViewModel inventoryViewModel,  string userId);
    Task<UpdateInventoryViewModel> UpdateGetInventoryAsync(int id);
    Task UpdateInventoryAsync(UpdateInventoryViewModel inventoryViewModel, int id);
    Task DeleteInventoryAsync(int id);

}