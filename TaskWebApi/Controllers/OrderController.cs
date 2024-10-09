using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static TaskWebApi.Models.TaskModalsAPI;
using TaskWebApi.Models;
using TaskWebApi.Data;

namespace TaskWebApi.Controllers
{
    public class OrderController : Controller
    {
        private readonly TaskDbContext _dbContext;
        public OrderController(TaskDbContext dbContext) 
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        [Route("api/getorders")]
        public IActionResult GetOrders()
        {
            var list = _dbContext.tblOrderMasters.Where(x => x.IsDeleted != true).ToList();
            return Ok(list);
        }

        [HttpPost]
        [Route("api/orders")]
        public async Task<IActionResult> PlaceOrder([FromBody] OrderPlacementViewModel model)
        {
            if (model == null || !model.OrderItems.Any())
            {
                return BadRequest("Invalid order data.");
            }

            try
            {
                var orderMaster = new tblOrderMaster
                {
                    CustomerId = model.CustomerId,
                    OrderedDate = model.OrderedDate,
                    OrderedAmount = model.TotalAmount,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedDate = DateTime.Now
                };

                _dbContext.tblOrderMasters.Add(orderMaster);
                await _dbContext.SaveChangesAsync(); // Save the master first to get the order ID

                foreach (var item in model.OrderItems)
                {
                    var orderDetail = new tblOrderDetails
                    {
                        OrderId = orderMaster.OrderId,
                        ItemId = item.ItemId,
                        Quantity = item.Quantity,
                        Cost = item.Quantity * item.ItemCost,
                        CreatedDate = DateTime.Now,
                        IsActive = true,
                        IsDeleted = false
                    };

                    _dbContext.tblOrderDetails.Add(orderDetail);
                }

                await _dbContext.SaveChangesAsync(); // Save all order details

                return Ok("Order placed successfully.");
            }
            catch (Exception ex)
            {
                // Log the exception for debugging
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
