using Microsoft.AspNetCore.Mvc;
using TaskWebApi.Data;
using TaskWebApi.Models;

namespace TaskWebApiIntegration.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        //public IActionResult Create()
        //{
        //    var model = new tblOrderMaster
        //    {
        //        OrderDetails = _context.tblItems
        //            .Select(item => new tblOrderDetails
        //            {
        //                ItemId = item.ItemId,
        //                Quantity = item.ItemId,
        //                Cost = item.ItemCost ?? 0
        //            }).ToList()
        //    };

        //    return View(model);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Create(tblOrderMaster model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        // Create OrderMaster
        //        var orderMaster = new tblOrderMaster
        //        {
        //            CustomerId = model.CustomerId,
        //            OrderedDate = DateTime.Now,
        //            OrderedAmount = model.OrderDetails.Sum(item => item.Cost * item.Quantity)
        //        };
        //        //_context.tblItems.Add(orderMaster);
        //        //_context.SaveChanges();

        //        //// Create OrderDetails
        //        //foreach (var orderItem in model.OrderItems)
        //        //{
        //        //    var orderDetails = new tblOrderDetails
        //        //    {
        //        //        OrderId = orderMaster.OrderId,
        //        //        ItemId = orderItem.ItemId,
        //        //        Quantity = orderItem.Quantity,
        //        //        Cost = orderItem.ItemCost * orderItem.Quantity
        //        //    };
        //        //    _context.tblOrderDetails.Add(orderDetails);
        //        //}

        //        //_context.SaveChanges();
        //        return RedirectToAction("Index"); // Redirect to order list or confirmation page
        //    }

        //    return View(model);
        //}
    }
}
