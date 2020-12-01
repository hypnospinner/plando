using System.Collections.Generic;
using Plando.Common;

namespace Plando.Models.Orders
{
    public class OrderCreatedEvent : EventBase, IAggregator<Order>
    {
        public int ClientId { get; set; }
        public int LaundryId { get; set; }
        public string Title { get; set; }

        public Order Push(Order aggregate)
        {
            aggregate.Id = Id;
            aggregate.ClientId = ClientId;
            aggregate.LaundryId = LaundryId;
            aggregate.Title = Title;
            aggregate.Status = OrderStatus.NEW;
            aggregate.Price = 0.0m;
            aggregate.Services = new List<ServiceInOrder>();

            return aggregate;
        }
    }
}