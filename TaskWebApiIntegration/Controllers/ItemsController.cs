using Microsoft.AspNetCore.Mvc;
using TaskWebApi.Data;
using TaskWebApi.Models;
using TaskWebApiIntegration.Services;

namespace TaskWebApiIntegration.Controllers
{
    public class ItemsController : Controller
    {
        private readonly ItemsServices _itemService;

        public ItemsController(ItemsServices itemService)
        {
            _itemService = itemService;
        }

        public async Task<IActionResult> Orders(string message)
        {
            try
            {
                ViewBag.message = message;
                var items = await _itemService.GetOrdersAsync();
                return View(items);
            }
            catch (Exception ex)
            {
                //ViewBag.Error = "Failed to load items from the API.";
                ViewBag.Error = ex.Message;
                return View();
            }
        }
        public async Task<IActionResult> Index(string message)
        {
            try
            { 
                ViewBag.message = message;
                //var items = await _itemService.GetItemsAsync();
                var items = await _itemService.GetItemsAsync();
                return View(items);
            }
            catch (Exception ex)
            {
                //ViewBag.Error = "Failed to load items from the API.";
                ViewBag.Error = ex.Message;
                return View(); 
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddItem(tblItem item)
        {
            try
            {
                bool result = await _itemService.AddItemAsync(item); 
                if (result)
                {
                    return RedirectToAction("Index", new { message = "Items successfully added!" });  
                }
                else
                {
                    ViewBag.Error = "Failed to add item.";
                    return View(item);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(item); 
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteItem(int ItemId)
        {
            try
            {
                bool result = await _itemService.DeleteItemAsync(ItemId);
                if (result)
                {
                    return RedirectToAction("Index", new {message = "Items successfully deleted!"});
                }
                else
                {
                    ViewBag.Error = "Failed to add item.";
                    return View(ItemId);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(ItemId); 
            }
        }

    }
}
