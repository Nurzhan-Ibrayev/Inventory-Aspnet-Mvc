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

    public async Task<InventoryViewModel> CreateInventoryAsync(CreateInventoryViewModel inventoryViewModel, string userId)
    {
        var inventoryModel = _mapper.Map<Inventory>(inventoryViewModel);
        inventoryModel.CreatorId = userId;
        await _inventoryRepository.AddAsync(inventoryModel);
        return _mapper.Map<InventoryViewModel>(inventoryModel);
    }
    
    
}