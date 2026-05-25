using ItransitionProjectMVC.Data;
using ItransitionProjectMVC.Models;
using ItransitionProjectMVC.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ItransitionProjectMVC.Repository;

public class ItemRepository : IItemRepository
{
    private readonly AppDBContext _context;

    public ItemRepository(AppDBContext context)
    {
        _context = context;
    }

    public async Task<List<Item>> GetByInventoryIdAsync(int inventoryId)
    {
        return await _context.Items
            .Where(i => i.InventoryId == inventoryId)
            .ToListAsync();
    }

    public async Task<Item?> GetByIdAsync(int id)
    {
        return await _context.Items
            .Include(i => i.Inventory)
            .Include(i => i.CreatedBy)
            .FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task<Item> AddAsync(Item item)
    {
        await _context.Items.AddAsync(item);
        await _context.SaveChangesAsync();
        return item;
    }

    public async Task UpdateAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Item item)
    {
        _context.Items.Remove(item);
        await _context.SaveChangesAsync();
    }
}