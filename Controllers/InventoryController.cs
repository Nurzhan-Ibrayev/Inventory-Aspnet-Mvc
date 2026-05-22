using System.Security.Claims;
using ItransitionProjectMVC.Sevices.Interfaces;
using ItransitionProjectMVC.ViewModels.Inventory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ItransitionProjectMVC.Controllers;

public class InventoryController:Controller
{
    private readonly IInventoryService _inventoryService;
    public InventoryController(IInventoryService inventoryService)
    {
        _inventoryService = inventoryService;
    }
    [HttpGet]
    [Authorize]
    public IActionResult Create()
    {
        var vm = new CreateInventoryViewModel();

        return View(vm);
    }
    [HttpPost]
    [Authorize]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateInventoryViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var inventory = await _inventoryService.CreateInventoryAsync(model, userId);
        return RedirectToAction("Index");
    }
}