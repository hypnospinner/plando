using System.ComponentModel.DataAnnotations.Schema;
using Plando.Common;

namespace Plando.Models.Orders
{
    public class ServiceCompletedEvent : EventBase, IAggregator<Order>
    {
        public int ServiceId { get; set; }
        public int OrderId { get; set; }


        public Order Push(Order aggregate)
        {
            throw new System.NotImplementedException();
        }
    }
}