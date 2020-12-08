using System.Linq;
using Plando.Common;

namespace Plando.Models.Orders
{
    public class OrderFinishedEvent : EventBase, IAggregator<Order>
    {
        public int OrderId { get; set; }

        public Order Push(Order aggregate)
        {
            if (aggregate is null)
                return null;

            aggregate.Id = OrderId;
            aggregate.Status = OrderStatus.FINISHED;
            aggregate.Price = 0;
            
            foreach (ServiceInOrder item in aggregate.Services)
                aggregate.Price += item.Price;

            return aggregate;
        }
    }
}