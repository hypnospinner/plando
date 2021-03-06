using System.Linq;
using Plando.Common;

namespace Plando.Models.Orders
{
    public class OrderFinishedEvent : EventBase, IAggregator<Order>
    {
        public int OrderId { get; set; }
        public OrderCreatedEvent OrderCreatedEvent { get; set; }
        public Order Push(Order aggregate)
        {
            if (aggregate is null)
                return null;

            aggregate.Status = OrderStatus.FINISHED;

            return aggregate;
        }
    }
}