using AutoMapper;
using ItransitionProjectMVC.Models;
using ItransitionProjectMVC.ViewModels.Inventory;

namespace ItransitionProjectMVC.Mappers;

public class InventoryMapper:Profile
{
    public InventoryMapper()
    {
        CreateMap<Inventory, InventoryViewModel>();
        CreateMap<CreateInventoryViewModel, Inventory>();
        CreateMap<UpdateInventoryViewModel, Inventory>();
        CreateMap<Inventory, UpdateInventoryViewModel>();
    }
}