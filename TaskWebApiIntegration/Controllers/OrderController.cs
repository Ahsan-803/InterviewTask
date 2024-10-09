using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using TaskWebApi.Data;
using TaskWebApi.Models;
using static TaskWebApiIntegration.Models.TasksMvcModals;

namespace TaskWebApiIntegration.Controllers
{
    public class OrderController : Controller
    {
        private readonly HttpClient _httpClient;

        public OrderController(HttpClient httpClient)
        {
            _httpClient = httpClient;
            //_httpClient.BaseAddress = new Uri("https://localhost:7299/api");  // API Base URL
        }
 
        // GET: Order/PlaceOrder
        public async Task<IActionResult> PlaceOrders()
        {
            var response = await _httpClient.GetAsync("https://localhost:7299/api/Items/GetItems");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var items = JsonConvert.DeserializeObject<List<OrderItemViewModel>>(data);

                var viewModel = new OrderPlacementViewModel
                {
                    CustomerId = 1, // Set a hardcoded or dynamic CustomerId
                    OrderItems = items
                };

                return View(viewModel);
            }

            return View(new OrderPlacementViewModel());
        }

        // POST: Order/PlaceOrder
        [HttpPost]
        public async Task<IActionResult> PlaceOrders(OrderPlacementViewModel orderModel)
        {
            var jsonData = JsonConvert.SerializeObject(orderModel);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("https://localhost:7299/api/orders", content);

            if (response.IsSuccessStatusCode)
            {
                ViewBag.Message = "Order placed successfully.";
                return RedirectToAction("OrderConfirmation");
            }
            else
            {
                var errorResponse = await response.Content.ReadAsStringAsync();
                ViewBag.Message = $"Error: {response.StatusCode}, Details: {errorResponse}";
                return View(orderModel);
            }
        }


        // GET: Order/OrderSuccess
        public IActionResult OrderConfirmation()
        { 
            return View();
        }
    }
}
