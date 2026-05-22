using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ItransitionProjectMVC.ViewModels.Inventory;

public class CreateInventoryViewModel
{
    [Required(ErrorMessage = "Название обязательно")]
    [Display(Name = "Название инвентаря")]
    public string Title { get; set; } = string.Empty;

    [Display(Name = "Описание (поддерживает Markdown)")]
    public string? Description { get; set; }

    [Display(Name = "Категория")]
    public int? CategoryId { get; set; }
    
    public IEnumerable<SelectListItem>? Categories { get; set; }

    [Display(Name = "Сделать публичным (все могут добавлять айтемы)")]
    public bool IsPublic { get; set; }

    [Display(Name = "Теги (через запятую)")]
    public string Tags { get; set; } = string.Empty;

    public string? ImageUrl { get; set; }

    public List<CustomFieldSettingViewModel> CustomFields { get; set; } = new();

    // public string CustomIdFormat { get; set; } = "Sequence";
}