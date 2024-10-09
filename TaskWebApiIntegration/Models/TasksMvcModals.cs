namespace TaskWebApiIntegration.Models
{
    public class TasksMvcModals
    {
        public class OrderPlacementViewModel
        {
            public int CustomerId { get; set; }  // Could be hardcoded or selected dynamically

            public DateTime OrderedDate { get; set; } = DateTime.Now;

            public List<OrderItemViewModel>? OrderItems { get; set; }

            public float TotalAmount
            {
                get
                {
                    return OrderItems?.Sum(item => item.Quantity * item.ItemCost) ?? 0;
                }
            }
        }

        public class OrderItemViewModel
        {
            public int ItemId { get; set; }
            public string? ItemDescription { get; set; }
            public float ItemCost { get; set; }
            public int Quantity { get; set; }
        }
    }
}
