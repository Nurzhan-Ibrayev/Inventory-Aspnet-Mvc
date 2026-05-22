using System.ComponentModel.DataAnnotations;

namespace ItransitionProjectMVC.ViewModels.Inventory;

public class CustomFieldSettingViewModel
{
    public string Type { get; set; } 
    public int Index { get; set; } 
    
    [Display(Name = "Название поля")]
    public string? Name { get; set; }
    
    [Display(Name = "Состояние")]
    public string State { get; set; } = "Hidden"; 
}