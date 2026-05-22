using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItransitionProjectMVC.Models;

public class Inventory
{
    public int Id { get; set; }

    [Required, MaxLength(256)]
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }

    [MaxLength(1024)]
    public string? ImageUrl { get; set; }

    public string CreatorId { get; set; }

    public int? CategoryId { get; set; }

    public bool IsPublic { get; set; } = false;

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

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    [Timestamp]
    public uint xmin { get; set; }

    [ForeignKey(nameof(CreatorId))]
    public AppUser Creator { get; set; }

    [ForeignKey(nameof(CategoryId))]
    public Category? Category { get; set; }

    public ICollection<Item> Items { get; set; } = [];
    public ICollection<Comment> Comments { get; set; } = [];
    public ICollection<InventoryAccess> AccessList { get; set; } = [];
    public ICollection<InventoryTag> InventoryTags { get; set; } = [];
}