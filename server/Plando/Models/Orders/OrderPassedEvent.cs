using Plando.Common;

namespace Plando.Models.Orders
{
    public class OrderPassedEvent : EventBase, IAggregator<Order>
    {
        public int OrderId { get; set; }

        public Order Push(Order aggregate)
        {
            if (aggregate is null)
                return null;
            
            aggregate.Id = OrderId;
            aggregate.Status = OrderStatus.PASSED;
            return aggregate;

        }
    }
}