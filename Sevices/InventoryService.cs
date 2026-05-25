using AutoMapper;
using ItransitionProjectMVC.Models;
using ItransitionProjectMVC.Repository.Interfaces;
using ItransitionProjectMVC.Sevices.Interfaces;
using ItransitionProjectMVC.ViewModels.Inventory;


namespace ItransitionProjectMVC.Sevices;

public class InventoryService:IInventoryService
{
    private readonly IInventoryRepository _inventoryRepository;
    private readonly IMapper _mapper;
    public InventoryService(IInventoryRepository repository,  IMapper mapper)
    {
        _inventoryRepository = repository;
        _mapper = mapper;
    }

    public async Task<List<InventoryViewModel>> GetAllInventoryAsync()
    {
        var inventories = await _inventoryRepository.GetAllAsync();
        return _mapper.Map<List<InventoryViewModel>>(inventories);
    }   
    public async Task<InventoryViewModel> GetByIdInventoryAsync(int id)
    {
        var inventory = await _inventoryRepository.GetByIdAsync(id);
        return _mapper.Map<InventoryViewModel>(inventory);
    } 
    public async Task<InventoryDetailsViewModel> GetByIdInventoryDetailsAsync(int id)
    {
        var inventory = await _inventoryRepository.GetByIdAsync(id);
        return _mapper.Map<InventoryDetailsViewModel>(inventory);
    } 

    public async Task CreateInventoryAsync(CreateInventoryViewModel inventoryViewModel, string userId)
    {
        var inventoryModel = _mapper.Map<Inventory>(inventoryViewModel);
        inventoryModel.CreatorId = userId;
        await _inventoryRepository.AddAsync(inventoryModel);
    }

    public async Task<UpdateInventoryViewModel> UpdateGetInventoryAsync(int id)
    {
        var inventory = await _inventoryRepository.GetByIdAsync(id);
        return _mapper.Map<UpdateInventoryViewModel>(inventory);
    }
    public async Task UpdateInventoryAsync(UpdateInventoryViewModel inventoryViewModel, int id)
    {
        var inventoryModel = await _inventoryRepository.GetByIdAsync(id);
        if (inventoryModel == null)
            throw new Exception("Inventory not found");

        Console.WriteLine($"BEFORE: Title={inventoryModel.Title}, IsPublic={inventoryModel.IsPublic}");
    
        _mapper.Map(inventoryViewModel, inventoryModel);
    
        Console.WriteLine($"AFTER: Title={inventoryModel.Title}, IsPublic={inventoryModel.IsPublic}");
    
        await _inventoryRepository.UpdateAsync();
    }
    public async Task DeleteInventoryAsync(int id)
    {
        var inventoryModel = await _inventoryRepository.GetByIdAsync(id);
        if (inventoryModel == null)
        {
            throw new Exception("Inventory not found");
        }
        await _inventoryRepository.DeleteAsync(inventoryModel);
    }
    
}