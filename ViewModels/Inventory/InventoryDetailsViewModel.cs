using System.ComponentModel.DataAnnotations;

namespace ItransitionProjectMVC.ViewModels.Inventory;

public class InventoryDetailsViewModel
{
    public int Id { get; set; }

    [Display(Name = "Название")]
    public string Title { get; set; } = string.Empty;

    [Display(Name = "Описание")]
    public string? Description { get; set; } // Здесь будет Markdown

    [Display(Name = "Изображение")]
    public string? ImageUrl { get; set; }

    [Display(Name = "Категория")]
    public string CategoryName { get; set; } = "Без категории";

    [Display(Name = "Автор")]
    public string CreatorUserName { get; set; } = string.Empty;

    [Display(Name = "Дата создания")]
    public DateTime CreatedAt { get; set; }

    [Display(Name = "Публичный")]
    public bool IsPublic { get; set; }

    // Теги передаем списком строк для удобного рендеринга значков (badges)
    public List<string> Tags { get; set; } = new();

    // Для Optimistic Locking (нужен при переходе к редактированию)
    public byte[] RowVersion { get; set; } = [];

    // Поля конфигурации (только те, что активны)
    // Это поможет нам динамически рисовать таблицу для Items
    public List<CustomFieldDisplayViewModel> ActiveFields { get; set; } = new();
}