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

    public List<string> Tags { get; set; } = new();



    // ── Custom string fields (single-line) ──────────────────────────
    [MaxLength(256)] public string? CustomString1Name { get; set; }
    [MaxLength(20)]  public string? CustomString1State { get; set; }

    [MaxLength(256)] public string? CustomString2Name { get; set; }
    [MaxLength(20)]  public string? CustomString2State { get; set; }

    [MaxLength(256)] public string? CustomString3Name { get; set; }
    [MaxLength(20)]  public string? CustomString3State { get; set; }

    // ── Custom multiline text fields ─────────────────────────────────
    [MaxLength(256)] public string? CustomMultiline1Name { get; set; }
    [MaxLength(20)]  public string? CustomMultiline1State { get; set; }

    [MaxLength(256)] public string? CustomMultiline2Name { get; set; }
    [MaxLength(20)]  public string? CustomMultiline2State { get; set; }

    [MaxLength(256)] public string? CustomMultiline3Name { get; set; }
    [MaxLength(20)]  public string? CustomMultiline3State { get; set; }

    // ── Custom numeric fields ─────────────────────────────────────────
    [MaxLength(256)] public string? CustomInt1Name { get; set; }
    [MaxLength(20)]  public string? CustomInt1State { get; set; }

    [MaxLength(256)] public string? CustomInt2Name { get; set; }
    [MaxLength(20)]  public string? CustomInt2State { get; set; }

    [MaxLength(256)] public string? CustomInt3Name { get; set; }
    [MaxLength(20)]  public string? CustomInt3State { get; set; }

    // ── Custom boolean (checkbox) fields ─────────────────────────────
    [MaxLength(256)] public string? CustomBool1Name { get; set; }
    [MaxLength(20)]  public string? CustomBool1State { get; set; }

    [MaxLength(256)] public string? CustomBool2Name { get; set; }
    [MaxLength(20)]  public string? CustomBool2State { get; set; }

    [MaxLength(256)] public string? CustomBool3Name { get; set; }
    [MaxLength(20)]  public string? CustomBool3State { get; set; }

    // ── Custom link/document fields ───────────────────────────────────
    [MaxLength(256)] public string? CustomLink1Name { get; set; }
    [MaxLength(20)]  public string? CustomLink1State { get; set; }

    [MaxLength(256)] public string? CustomLink2Name { get; set; }
    [MaxLength(20)]  public string? CustomLink2State { get; set; }

    [MaxLength(256)] public string? CustomLink3Name { get; set; }
    [MaxLength(20)]  public string? CustomLink3State { get; set; }
}