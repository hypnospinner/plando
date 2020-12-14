using Plando.Common;

namespace Plando.Models.Orders
{
    public class ServiceRemovedEvent : EventBase, IAggregator<Order>
    {
        public int ServiceId { get; set; }
        public int OrderId { get; set; }
        public OrderCreatedEvent OrderCreatedEvent { get; set; }
        public int ServiceAddedEventId { get; set; }
        public ServiceAddedEvent ServiceAddedEvent { get; set; }

        public Order Push(Order aggregate)
        {
            throw new System.NotImplementedException();
        }
    }
}