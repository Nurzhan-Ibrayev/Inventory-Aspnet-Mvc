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
    public async Task<IActionResult> Create(CreateInventoryViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            return View(viewModel);
        }
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        await _inventoryService.CreateInventoryAsync(viewModel, userId);
        return RedirectToAction(
            "Index",
            "Home");
    }
    
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> Edit(int id)
    {
        var vm = await _inventoryService.UpdateGetInventoryAsync(id);
        return View(vm);
    }
    [HttpPost]
    [Authorize]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(UpdateInventoryViewModel viewModel, int id)
    {
        Console.WriteLine($">>> Edit POST: id={id}, viewModel.Id={viewModel.Id}, Title={viewModel.Title}");
    
        if (!ModelState.IsValid)
        {
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                Console.WriteLine($">>> ModelState error: {error.ErrorMessage}");
            return View(viewModel);
        }
    
        await _inventoryService.UpdateInventoryAsync(viewModel, id);
        return RedirectToAction(
            "Index",
            "Home");
    }

    [HttpPost]
    [Authorize]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        await _inventoryService.DeleteInventoryAsync(id);
        return RedirectToAction(
            "Index",
            "Home");
    }
}