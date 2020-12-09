using Plando.Common;

namespace Plando.Models.Orders
{
    public class ServiceAddedEvent : EventBase, IAggregator<Order>
    {
        public int ServiceId { get; set; }
        public int OrderId { get; set; }

        public Order Push(Order aggregate)
        {
            if (aggregate is null)
                return null;
            
            aggregate.Id = OrderId;
            //aggregate.Services.Add()
            
            
        }
    }
}