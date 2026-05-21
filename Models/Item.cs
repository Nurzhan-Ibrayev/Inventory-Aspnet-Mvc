using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItransitionProjectMVC.Models;

public class Item
{
    public int Id { get; set; }

    public int InventoryId { get; set; }
    
    [Required, MaxLength(256)]
    public string CustomId { get; set; } = string.Empty;

    public string CreatedById { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    [Timestamp]
    public byte[] RowVersion { get; set; } = [];

    // ── Custom string values (single-line) ───────────────────────────
    [MaxLength(1024)] public string? CustomString1Value { get; set; }
    [MaxLength(1024)] public string? CustomString2Value { get; set; }
    [MaxLength(1024)] public string? CustomString3Value { get; set; }

    // ── Custom multiline text values ──────────────────────────────────
    public string? CustomMultiline1Value { get; set; }
    public string? CustomMultiline2Value { get; set; }
    public string? CustomMultiline3Value { get; set; }

    // ── Custom numeric values ─────────────────────────────────────────
    public double? CustomInt1Value { get; set; }
    public double? CustomInt2Value { get; set; }
    public double? CustomInt3Value { get; set; }

    // ── Custom boolean values ─────────────────────────────────────────
    public bool? CustomBool1Value { get; set; }
    public bool? CustomBool2Value { get; set; }
    public bool? CustomBool3Value { get; set; }

    // ── Custom link/document values ───────────────────────────────────
    [MaxLength(2048)] public string? CustomLink1Value { get; set; }
    [MaxLength(2048)] public string? CustomLink2Value { get; set; }
    [MaxLength(2048)] public string? CustomLink3Value { get; set; }

    // Navigation
    [ForeignKey(nameof(InventoryId))]
    public Inventory Inventory { get; set; } = null!;

    [ForeignKey(nameof(CreatedById))]
    public AppUser CreatedBy { get; set; } = null!;

    public ICollection<Like> Likes { get; set; } = [];
}