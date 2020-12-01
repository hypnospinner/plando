using Plando.Common;

namespace Plando.Models.Orders
{
    public class OrderPassedEvent : EventBase, IAggregator<Order>
    {
        public int OrderId { get; set; }

        public Order Push(Order aggregate)
        {
            throw new System.NotImplementedException();
        }
    }
}