using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ItransitionProjectMVC.ViewModels.Inventory;

public class UpdateInventoryViewModel
{
    public int Id { get; set; }
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

    // public string CustomIdFormat { get; set; } = "Sequence";
}