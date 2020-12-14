using System;
using Plando.Common;
using Plando.Models.Services;

namespace Plando.Models.Orders
{
    public class ServiceAddedEvent : EventBase, IAggregator<Order>
    {
        public int ServiceId { get; set; }
        public int OrderId { get; set; }
        public OrderCreatedEvent OrderCreatedEvent { get; set; }
        public Order Push(Order aggregate)
        {
            if (aggregate is null)
                return null;

            aggregate.Id = OrderId;
            //aggregate.Services.Add()
            throw new NotImplementedException();
        }
    }
}