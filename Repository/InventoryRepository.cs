using ItransitionProjectMVC.Data;
using ItransitionProjectMVC.Models;
using ItransitionProjectMVC.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ItransitionProjectMVC.Repository;

public class InventoryRepository:IInventoryRepository
{
    private readonly AppDBContext _context;
    public InventoryRepository(AppDBContext context)
    {
        _context = context;
    }

    public async Task<List<Inventory>> GetAllAsync()
    {
        return await _context.Inventories.ToListAsync();
    }

    public async Task<Inventory?> GetByIdAsync(int id)
    {
        return await _context.Inventories.FirstOrDefaultAsync(x => x.Id == id);
    }
    
    public async Task<Inventory> AddAsync(Inventory inventoryModel)
    {
        await _context.AddAsync(inventoryModel);
        await _context.SaveChangesAsync();
        return inventoryModel;
    }

    public async Task UpdateAsync()
    {
        
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Inventory inventoryModel)
    {
        _context.Inventories.Remove(inventoryModel);
        await _context.SaveChangesAsync();
    }
}
