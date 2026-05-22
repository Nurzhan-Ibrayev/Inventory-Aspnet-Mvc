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
        vm.CustomFields = new List<CustomFieldSettingViewModel>
        {
            new() { Type = "String", Index = 1 },
            new() { Type = "String", Index = 2 },
            new() { Type = "String", Index = 3 },

            new() { Type = "Text", Index = 1 },
            new() { Type = "Text", Index = 2 },
            new() { Type = "Text", Index = 3 },

            new() { Type = "Number", Index = 1 },
            new() { Type = "Number", Index = 2 },
            new() { Type = "Number", Index = 3 }
        };

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