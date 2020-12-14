using System;
using Plando.Common;

namespace Plando.Models.Orders
{
    public class OrderCancelledEvent : EventBase, IAggregator<Order>
    {
        public int OrderId { get; set; }
        public OrderCreatedEvent OrderCreatedEvent { get; set; }

        public Order Push(Order aggregate)
        {
            if (aggregate is null)
                return null;

            if (aggregate.Status == OrderStatus.NEW)
            {
                aggregate.Id = OrderId;
                aggregate.Status = OrderStatus.CANCELLED;
                aggregate.Price = 0;

                return aggregate;
            }
            else
            {
                throw new Exception("Can't cancell the order 'cause it is in progress");
            }

        }
    }

}