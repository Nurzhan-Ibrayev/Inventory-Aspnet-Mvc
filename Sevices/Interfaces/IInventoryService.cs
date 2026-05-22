using ItransitionProjectMVC.ViewModels.Inventory;

namespace ItransitionProjectMVC.Sevices.Interfaces;

public interface IInventoryService
{
    Task<List<InventoryViewModel>> GetAllInventoryAsync();
    Task<InventoryViewModel> CreateInventoryAsync(CreateInventoryViewModel inventoryViewModel,  string userId);
}