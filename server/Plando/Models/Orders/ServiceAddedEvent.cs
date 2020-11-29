using System.ComponentModel.DataAnnotations.Schema;

namespace Plando.Models.Orders
{
    public class ServiceAddedEvent : EventBase
    {
        public int ServiceId { get; set; }
        public int OrderId { get; set; }
    }
}