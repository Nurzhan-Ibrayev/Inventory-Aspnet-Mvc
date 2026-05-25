using AutoMapper;
using ItransitionProjectMVC.Models;
using ItransitionProjectMVC.ViewModels.Item;

namespace ItransitionProjectMVC.Mappers;

public class ItemMapper : Profile
{
    public ItemMapper()
    {
        CreateMap<Item, ItemViewModel>()
            .ForMember(d => d.CreatedByUsername, o => o.MapFrom(s => s.CreatedBy.UserName));

        CreateMap<Item, UpdateItemViewModel>()
            .ForMember(d => d.Inventory, o => o.Ignore());

        CreateMap<UpdateItemViewModel, Item>()
            .ForMember(d => d.Inventory, o => o.Ignore())
            .ForMember(d => d.CreatedBy, o => o.Ignore())
            .ForMember(d => d.Likes, o => o.Ignore())
            .ForMember(d => d.CreatedById, o => o.Ignore())
            .ForMember(d => d.CreatedAt, o => o.Ignore());

        CreateMap<CreateItemViewModel, Item>()
            .ForMember(d => d.Inventory, o => o.Ignore())
            .ForMember(d => d.CreatedBy, o => o.Ignore())
            .ForMember(d => d.Likes, o => o.Ignore())
            .ForMember(d => d.CreatedById, o => o.Ignore())
            .ForMember(d => d.CreatedAt, o => o.Ignore());
    }
}