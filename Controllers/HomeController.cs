using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ItransitionProjectMVC.Models;
using ItransitionProjectMVC.Sevices.Interfaces;
using ItransitionProjectMVC.ViewModels.Inventory;

namespace ItransitionProjectMVC.Controllers;

public class HomeController : Controller
{
    private readonly IInventoryService _inventoryService;
    public HomeController(IInventoryService inventoryService)
    {
        _inventoryService = inventoryService;
    }
    [HttpGet]
    public async Task<IActionResult>  Index()
    {
        var inventories = await _inventoryService.GetAllInventoryAsync();
        return View(inventories);
    }

    
   
}