using Microsoft.AspNetCore.Mvc;
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

        public async Task<IActionResult> Index()
        {
            try
            {
                // Call the service to get the list of items from the API
                var items = await _itemService.GetItemsAsync();
                return View(items); // Pass the data to the view
            }
            catch (Exception ex)
            {
                // Handle exceptions and display an error message
                ViewBag.Error = "Failed to load items from the API.";
                return View(); 
            }
        }
    }
}
