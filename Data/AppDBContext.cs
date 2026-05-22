using ItransitionProjectMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace ItransitionProjectMVC.Data;

public class AppDBContext : IdentityDbContext<AppUser>
{
    public AppDBContext(DbContextOptions<AppDBContext> options)
     : base(options)
    {
    }
    
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Tag> Tags => Set<Tag>();
    public DbSet<Inventory> Inventories => Set<Inventory>();
    public DbSet<InventoryAccess> InventoryAccesses => Set<InventoryAccess>();
    public DbSet<InventoryTag> InventoryTags => Set<InventoryTag>();
    public DbSet<Item> Items => Set<Item>();
    public DbSet<Comment> Comments => Set<Comment>();
    public DbSet<Like> Likes => Set<Like>();
 
    protected override void OnModelCreating(ModelBuilder mb)
    {
        base.OnModelCreating(mb);
   
        mb.Entity<Tag>(e =>
        {
            e.HasIndex(t => t.Name).IsUnique();
        });
 
        // ── Inventory ────────────────────────────────────────────────────
        mb.Entity<Inventory>(e =>
        {
         
         e.HasOne(i => i.Creator)
          .WithMany(u => u.OwnedInventories)
          .HasForeignKey(i => i.CreatorId)
          .OnDelete(DeleteBehavior.Cascade);

         e.HasOne(i => i.Category)
          .WithMany(c => c.Inventories)
          .HasForeignKey(i => i.CategoryId)
          .OnDelete(DeleteBehavior.SetNull);

         e.HasIndex(i => new { i.Title, i.Description })
          .HasDatabaseName("IX_Inventories_FullText");
        });
 
     
 
        // ── InventoryAccess ───────────────────────────────────────────────
        mb.Entity<InventoryAccess>(e =>
        {
            e.HasKey(a => new { a.InventoryId, a.UserId });
 
            e.HasOne(a => a.Inventory)
             .WithMany(i => i.AccessList)
             .HasForeignKey(a => a.InventoryId)
             .OnDelete(DeleteBehavior.Cascade);
 
            e.HasOne(a => a.User)
             .WithMany(u => u.InventoryAccesses)
             .HasForeignKey(a => a.UserId)
             .OnDelete(DeleteBehavior.Cascade);
        });
 
        // ── InventoryTag ──────────────────────────────────────────────────
        mb.Entity<InventoryTag>(e =>
        {
            e.HasKey(it => new { it.InventoryId, it.TagId });
 
            e.HasOne(it => it.Inventory)
             .WithMany(i => i.InventoryTags)
             .HasForeignKey(it => it.InventoryId)
             .OnDelete(DeleteBehavior.Cascade);
 
            e.HasOne(it => it.Tag)
             .WithMany(t => t.InventoryTags)
             .HasForeignKey(it => it.TagId)
             .OnDelete(DeleteBehavior.Cascade);
        });
 
        // ── Item ──────────────────────────────────────────────────────────
        mb.Entity<Item>(e =>
        {
            // Composite unique index — custom_id is unique within one inventory
            e.HasIndex(i => new { i.InventoryId, i.CustomId })
             .IsUnique()
             .HasDatabaseName("UX_Items_InventoryId_CustomId");
 
            e.HasOne(i => i.Inventory)
             .WithMany(inv => inv.Items)
             .HasForeignKey(i => i.InventoryId)
             .OnDelete(DeleteBehavior.Cascade);
 
            e.HasOne(i => i.CreatedBy)
             .WithMany(u => u.CreatedItems)
             .HasForeignKey(i => i.CreatedById)
             .OnDelete(DeleteBehavior.Restrict);
        });
 
        // ── Comment ───────────────────────────────────────────────────────
        mb.Entity<Comment>(e =>
        {
            e.HasOne(c => c.Inventory)
             .WithMany(i => i.Comments)
             .HasForeignKey(c => c.InventoryId)
             .OnDelete(DeleteBehavior.Cascade);
 
            e.HasOne(c => c.User)
             .WithMany(u => u.Comments)
             .HasForeignKey(c => c.UserId)
             .OnDelete(DeleteBehavior.Cascade);
        });
 
        // ── Like ──────────────────────────────────────────────────────────
        mb.Entity<Like>(e =>
        {
            e.HasKey(l => new { l.ItemId, l.UserId });
 
            e.HasOne(l => l.Item)
             .WithMany(i => i.Likes)
             .HasForeignKey(l => l.ItemId)
             .OnDelete(DeleteBehavior.Cascade);
 
            e.HasOne(l => l.User)
             .WithMany(u => u.Likes)
             .HasForeignKey(l => l.UserId)
             .OnDelete(DeleteBehavior.Cascade);
        });
    }
}