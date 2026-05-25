using AutoMapper;
using ItransitionProjectMVC.Models;
using ItransitionProjectMVC.Repository.Interfaces;
using ItransitionProjectMVC.Sevices.Interfaces;
using ItransitionProjectMVC.ViewModels.Item;

namespace ItransitionProjectMVC.Services;

public class ItemService : IItemService
{
    private readonly IItemRepository _itemRepository;
    private readonly IInventoryRepository _inventoryRepository;
    private readonly IMapper _mapper;
    private readonly IInventoryService _inventoryService;

    public ItemService(
        IItemRepository itemRepository,
        IInventoryRepository inventoryRepository,
        IMapper mapper,
        IInventoryService inventoryService
        )
    {
        _itemRepository = itemRepository;
        _inventoryRepository = inventoryRepository;
        _mapper = mapper;
        _inventoryService = inventoryService;
    }

    public async Task<InventoryItemsViewModel> GetInventoryItemsAsync(int inventoryId, string? userId)
    {
        var inventory = await _inventoryRepository.GetByIdAsync(inventoryId);
        if (inventory == null)
        {
            return null;
        }
            

        var items = await _itemRepository.GetByInventoryIdAsync(inventoryId);


        bool canEdit = userId != null && (
            inventory.CreatorId == userId ||
            inventory.IsPublic ||
            inventory.AccessList.Any(a => a.UserId == userId)
        );

        var vm = new InventoryItemsViewModel
        {
            InventoryId = inventoryId,
            InventoryTitle = inventory.Title,
            CanEdit = canEdit,

            CustomString1Name = inventory.CustomString1Name,
            CustomString1State = inventory.CustomString1State,
            CustomString2Name = inventory.CustomString2Name,
            CustomString2State = inventory.CustomString2State,
            CustomString3Name = inventory.CustomString3Name,
            CustomString3State = inventory.CustomString3State,

            CustomMultiline1Name = inventory.CustomMultiline1Name,
            CustomMultiline1State = inventory.CustomMultiline1State,
            CustomMultiline2Name = inventory.CustomMultiline2Name,
            CustomMultiline2State = inventory.CustomMultiline2State,
            CustomMultiline3Name = inventory.CustomMultiline3Name,
            CustomMultiline3State = inventory.CustomMultiline3State,

            CustomInt1Name = inventory.CustomInt1Name,
            CustomInt1State = inventory.CustomInt1State,
            CustomInt2Name = inventory.CustomInt2Name,
            CustomInt2State = inventory.CustomInt2State,
            CustomInt3Name = inventory.CustomInt3Name,
            CustomInt3State = inventory.CustomInt3State,

            CustomBool1Name = inventory.CustomBool1Name,
            CustomBool1State = inventory.CustomBool1State,
            CustomBool2Name = inventory.CustomBool2Name,
            CustomBool2State = inventory.CustomBool2State,
            CustomBool3Name = inventory.CustomBool3Name,
            CustomBool3State = inventory.CustomBool3State,

            CustomLink1Name = inventory.CustomLink1Name,
            CustomLink1State = inventory.CustomLink1State,
            CustomLink2Name = inventory.CustomLink2Name,
            CustomLink2State = inventory.CustomLink2State,
            CustomLink3Name = inventory.CustomLink3Name,
            CustomLink3State = inventory.CustomLink3State,

            Items = _mapper.Map<List<ItemViewModel>>(items)
        };

        return vm;
    }

    public async Task<UpdateItemViewModel?> GetItemForEditAsync(int itemId)
    {
        var item = await _itemRepository.GetByIdAsync(itemId);
        if (item == null) return null;

        var vm = _mapper.Map<UpdateItemViewModel>(item);
        vm.Inventory = await _inventoryService.GetByIdInventoryDetailsAsync(item.InventoryId);
        return vm;
    }

    public async Task CreateItemAsync(CreateItemViewModel vm, string userId)
    {
        var inventory = await _inventoryRepository.GetByIdAsync(vm.InventoryId)
            ?? throw new Exception("Inventory not found");

        var item = _mapper.Map<Item>(vm);
        item.CreatedById = userId;
        item.CustomId = await GenerateCustomIdAsync(inventory);

        await _itemRepository.AddAsync(item);
    }

    public async Task UpdateItemAsync(UpdateItemViewModel vm)
    {
        var item = await _itemRepository.GetByIdAsync(vm.Id)
            ?? throw new Exception("Item not found");

        _mapper.Map(vm, item);
        item.UpdatedAt = DateTime.UtcNow;

        await _itemRepository.UpdateAsync();
    }

    public async Task DeleteItemAsync(int itemId)
    {
        var item = await _itemRepository.GetByIdAsync(itemId)
            ?? throw new Exception("Item not found");

        await _itemRepository.DeleteAsync(item);
    }

    // Простая генерация CustomId — sequence внутри инвентаря.
    // Позже заменишь на полноценный конструктор по CustomIdFormat.
    private async Task<string> GenerateCustomIdAsync(Inventory inventory)
    {
        var items = await _itemRepository.GetByInventoryIdAsync(inventory.Id);
        var next = items.Count + 1;
        return next.ToString("D6"); // "000001", "000002", ...
    }
}