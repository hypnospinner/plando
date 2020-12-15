using Plando.Common;

namespace Plando.Models.Orders
{
    public class OrderPutInProgressEvent : EventBase, IAggregator<Order>
    {
        public int OrderId { get; set; }
        public OrderCreatedEvent OrderCreatedEvent { get; set; }
        public Order Push(Order aggregate)
        {
            throw new System.NotImplementedException();
        }
    }
}