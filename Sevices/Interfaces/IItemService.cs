using ItransitionProjectMVC.ViewModels.Item;

namespace ItransitionProjectMVC.Sevices.Interfaces;

public interface IItemService
{
    Task<InventoryItemsViewModel> GetInventoryItemsAsync(int inventoryId, string? userId);
    Task<UpdateItemViewModel?> GetItemForEditAsync(int itemId);
    Task CreateItemAsync(CreateItemViewModel vm, string userId);
    Task UpdateItemAsync(UpdateItemViewModel vm);
    Task DeleteItemAsync(int itemId);

}