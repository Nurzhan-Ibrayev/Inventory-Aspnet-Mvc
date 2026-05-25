using System.Security.Claims;
using ItransitionProjectMVC.Sevices.Interfaces;
using ItransitionProjectMVC.ViewModels.Item;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ItransitionProjectMVC.Controllers;

public class ItemController : Controller
{
    private readonly IItemService _itemService;
    private readonly IInventoryService _inventoryService;

    public ItemController(IItemService itemService,  IInventoryService inventoryService)
    {
        _itemService = itemService;
        _inventoryService = inventoryService;
    }

    // GET /Item/Index/5  — таблица items инвентаря
    [HttpGet]
    [Route("Item/Index/{inventoryId:int}")]
    public async Task<IActionResult> Index(int inventoryId)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var vm = await _itemService.GetInventoryItemsAsync(inventoryId, userId);
        if (vm == null)
            return NotFound();
        return View(vm);
    }

    // GET /Item/Create?inventoryId=5
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> Create(int inventoryId)
    {
        var inventory = await _inventoryService.GetByIdInventoryDetailsAsync(inventoryId);

        if (inventory == null)
        {
            return NotFound();
        }

        var vm = new CreateItemViewModel
        {
            InventoryId = inventoryId,
            Inventory = inventory
        };

        return View(vm);
    }

    [HttpPost]
    [Authorize]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateItemViewModel vm)
    {
        if (!ModelState.IsValid)
        {

            vm.Inventory =
                await _inventoryService.GetByIdInventoryDetailsAsync(vm.InventoryId);

            return View(vm);
        }

        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

        await _itemService.CreateItemAsync(vm, userId);
        return RedirectToAction("Index", new { vm.InventoryId });
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> Edit(int id)
    {
        var vm = await _itemService.GetItemForEditAsync(id);
        return View(vm);
    }

    [HttpPost]
    [Authorize]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(UpdateItemViewModel vm)
    {
        if (!ModelState.IsValid)
            return View(vm);

        await _itemService.UpdateItemAsync(vm);
        return RedirectToAction("Index", new { inventoryId = vm.InventoryId });
    }

    [HttpPost]
    [Authorize]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id, int inventoryId)
    {
        await _itemService.DeleteItemAsync(id);
        return RedirectToAction("Index", new { inventoryId });
    }
}